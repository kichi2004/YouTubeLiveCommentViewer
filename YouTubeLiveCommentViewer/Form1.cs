using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetOpenAuth.Messaging;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using YouTubeLiveCommentViewer.Properties;
using SystemTimer = System.Timers.Timer;

// ReSharper disable LocalizableElement

namespace YouTubeLiveCommentViewer
{
    public partial class Form1 : Form
    {
        //private static string _bouyomiLast;
        private string _videoId;
        private string _channelId;
        private string _liveChatId;
        private bool _first = true;
        private bool _connecting;
        private readonly WebClient _webclient = new WebClient {Encoding = Encoding.UTF8};
        private readonly Regex _regex = new Regex(@"(?!by[a-z]+)([@＠])\s*([^\d@＠()][^<>/ ]+)");
        private readonly YouTubeService _youtube;
        private DataGridViewCellEventArgs _mouseLocation;
        private readonly List<string> _messageIdsOld = new List<string>();

        private readonly Dictionary<string,
                (string id, string senderId, string senderName, bool isOwnerOrModerator,
                string text, DateTime time, string sender)> _messages =
                new Dictionary<string, ValueTuple<string, string, string, bool, string, DateTime, string>>();

        private readonly Dictionary<string, string> _kotehan = new Dictionary<string, string>();

        private readonly Dictionary<string, LiveChatMessage> _messagesDictionary =
            new Dictionary<string, LiveChatMessage>();

        private readonly List<string> _addingMessageIds = new List<string>();
        private List<string> _messagesIdsDiff = new List<string>();
        private readonly List<string> _alreadyDeletedIds = new List<string>();

        private readonly SystemTimer _timer;


        private static readonly DataGridViewCellStyle StyleOwner = new DataGridViewCellStyle {
            ForeColor = Settings.Default.ownerFore,
            BackColor = Settings.Default.ownerBack,
            //Font =  Settings.Default.font
        };

        private static readonly DataGridViewCellStyle StyleModerator = new DataGridViewCellStyle {
            ForeColor = Settings.Default.moderatorFore,
            BackColor = Settings.Default.moderatorBack,
            //Font = Settings.Default.font
        };

        private static readonly DataGridViewCellStyle StyleSponser = new DataGridViewCellStyle {
            ForeColor = Settings.Default.sponserFore,
            BackColor = Settings.Default.sponserBack,
            //Font = Settings.Default.font
        };

        private static readonly DataGridViewCellStyle StyleNormal = new DataGridViewCellStyle {
            ForeColor = Settings.Default.normalFore,
            BackColor = Settings.Default.normalBack,
            //Font = Settings.Default.font
        };

        private static readonly DataGridViewCellStyle StyleDeleted = new DataGridViewCellStyle {
            ForeColor = Color.FromArgb(90, 90, 90),
            BackColor = Settings.Default.normalBack
            //Font = Settings.Default.font
        };

        public Form1()
        {
            InitializeComponent();
            while (!(File.Exists("apikey.txt") & File.Exists("client_secret.json")))
            {
                if (MessageBox.Show("apikey.txt または client_secret.json がありません。", "エラー",
                        MessageBoxButtons.RetryCancel) != DialogResult.Retry) Application.Exit();
            }


            // ReSharper disable once AssignmentIsFullyDiscarded
            _ = this.Handle;

            //var c2 = new DataGridViewLinkColumn{
            //    Name = "ユーザー名",
            //    Text = "ユーザー名",
            //    TrackVisitedState = false
            //};
            //dataGridView1.Columns.Add(c2);
            dataGridView.Columns.Add("name", "ユーザー名");
            dataGridView.Columns.Add("comment", "コメント");
            dataGridView.Columns.Add("time", "時間");
            dataGridView.Columns.Add("channel", "チャンネル名");
            dataGridView.AllowUserToResizeRows = false;

            //var messagesDictionary = new Dictionary<string, object[]>();

            this.FormClosing += this.OnFormClosing;
            this.button1.Click += this.SendMessage;
            this.connectButton.Click += ConnectButtonOnClick;
            this.disconecctButton.Click += this.Disconnect;
            this.コメントをコピーToolStripMenuItem.Click += this.CopyComment;
            this.メッセージを削除ToolStripMenuItem.Click += this.DeleteMessage;
            this.ブロックするToolStripMenuItem.Click += this.Block;
            this.タイムアウトにするToolStripMenuItem.Click += this.Block;
            this.ユーザー情報編集ToolStripMenuItem.Click += this.EditUser;
            this.コテハン一覧を表示CToolStripMenuItem.Click += this.ShowKotehanWindow;
            this.閉じるXToolStripMenuItem.Click += (s, e) => Close();
            this.放送ページを開くLToolStripMenuItem.Click += OpenLive;
            this.コテハンを保存ToolStripMenuItem.Click += (s, e) => SaveKotehan();
            //this.設定8SToolStripMenuItem.Click += (s, e) => { new SettingsForm().ShowDialog(); };

            void EventBouyomi1(object s, EventArgs e)
            {
                bouyomi1_0.Checked =
                    bouyomi1_1.Checked =
                        bouyomi1_2.Checked =
                            bouyomi1_3.Checked = false;
                ((ToolStripMenuItem) s).Checked = true;
            }

            void EventBouyomi2(object s, EventArgs e)
            {
                bouyomi2_0.Checked =
                    bouyomi2_1.Checked =
                        bouyomi2_2.Checked =
                            bouyomi2_3.Checked = false;
                ((ToolStripMenuItem) s).Checked = true;
            }

            this.bouyomi1_0.Click += EventBouyomi1;
            this.bouyomi1_1.Click += EventBouyomi1;
            this.bouyomi1_2.Click += EventBouyomi1;
            this.bouyomi1_3.Click += EventBouyomi1;

            this.bouyomi2_0.Click += EventBouyomi2;
            this.bouyomi2_1.Click += EventBouyomi2;
            this.bouyomi2_2.Click += EventBouyomi2;
            this.bouyomi2_3.Click += EventBouyomi2;

            棒読みちゃん読み上げToolStripMenuItem.Checked = Settings.Default.bouyomi;
            this.削除時に非表示にするToolStripMenuItem.Checked = Settings.Default.hideOnDelete;

            this.dataGridView.CellMouseEnter += (_, e) => _mouseLocation = e;
            this.textBox1.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                    SendMessage(s, null);
            };

            var apiKey = File.ReadAllText("apikey.txt");
            UserCredential credential;
            using (var stream = File.OpenRead("client_secret.json"))
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] {YouTubeService.Scope.Youtube},
                    "user",
                    CancellationToken.None
                ).Result;
            _youtube = new YouTubeService(new BaseClientService.Initializer {
                HttpClientInitializer = credential,
                ApplicationName = "YouTubeLiveCommentViewer for NDQinfo",
                ApiKey = apiKey
            });

            try
            {
                if (!File.Exists("users.csv")) File.Create("users.csv");
                foreach (var text in File.ReadAllLines("users.csv", Encoding.UTF8))
                {
                    var split = text.Replace("\r", "").Split(',');
                    if (split.Length == 2 && !_kotehan.ContainsKey(split[0])) _kotehan.Add(split[0], split[1]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("コテハンの読み込みに失敗しました。",
                    "YouTubeLiveCommentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView.Font = new Font("Meiryo UI", 9);
            foreach (DataGridViewColumn c in dataGridView.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView.Columns[0].Width = Settings.Default.row1;
            dataGridView.Columns[1].Width = Settings.Default.row2;
            dataGridView.Columns[2].Width = Settings.Default.row3;
            dataGridView.Columns[3].Width = Settings.Default.row4;
            dataGridView.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //dataGridView.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.dataGridView.SelectionChanged += (s, e) => this.dataGridView.ClearSelection();
            
            switch (Settings.Default.bouyomi1)
            {
                case 1:
                    EventBouyomi1(bouyomi1_1, null);
                    break;
                case 2:
                    EventBouyomi1(bouyomi1_2, null);
                    break;
                case 3:
                    EventBouyomi1(bouyomi1_3, null);
                    break;
                default:
                    bouyomi1_0.Checked = true;
                    break;

            }

            switch (Settings.Default.bouyomi2)
            {
                case 1:
                    EventBouyomi2(bouyomi2_1, null);
                    break;
                case 2:
                    EventBouyomi2(bouyomi2_2, null);
                    break;
                case 3:
                    EventBouyomi2(bouyomi2_3, null);
                    break;
                default:
                    bouyomi2_0.Checked = true;
                    break;
            }

            if (Settings.Default.form_size != default(Size))
                this.Size = Settings.Default.form_size;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.ContextMenuStrip = contextMenuStrip1;
            }

            _timer = new SystemTimer(1000);
            _timer.Elapsed += (s, e) => Function();
            //Bouyomi("ユーチューブライブコメントビューワーを起動しました。");


        }

        private void Function()
        {
            var now = DateTime.Now;
            if (now.Second == 0 && now.Minute % 10 == 0)
                Log("接続中");
            try
            {
                var messageObjects = this._youtube
                    .LiveChatMessages.List(this._liveChatId, "snippet,authorDetails")
                    .Execute().Items;
                this._addingMessageIds.Clear();
                this._messagesDictionary.Clear();
                foreach (var value in messageObjects.Distinct())
                {
                    if (this._addingMessageIds.Contains(value.Id)) continue;
                    this._addingMessageIds.Add(value.Id);
                    this._messagesDictionary.Add(value.Id, value);
                }

                var old = this._messageIdsOld;
                this._messagesIdsDiff = this._addingMessageIds.Where(x => !old.Contains(x)).ToList();
                if (this._messagesIdsDiff.Any())
                {
                    Log($"新規メッセージ数 {this._messagesIdsDiff.Count}件");
                }

                var col = new List<DataGridViewRow>();
                    //var i2 = 0;
                    foreach (var v in this._messagesIdsDiff)
                    {
                        var value = this._messagesDictionary[v];
                        col.Add(this.GetNewRows(value));
                        //Log("added a row: " + ++i2);
                    }
                

                //Log("adding rows complete.");
                var del = _messages
                    .Where(x => !this._addingMessageIds.Contains(x.Key) && !this._alreadyDeletedIds.Contains(x.Key))
                    .ToDictionary(x => x.Key, x => x.Value);
                if (del.Any())
                {
                    Log($"削除メッセージ {del.Count}件あり");
                    if (this.削除時に非表示にするToolStripMenuItem.Checked) {
                        for (var i = this._messages.Count - 1; i >= 0; i--) {
                            var el = _messages.ElementAt(i);
                            var (_, _, name, _, _, time, sender) = el.Value;
                            if (time.AddHours(2).AddMinutes(-1) < DateTime.Now) break;
                            if (!del.ContainsKey(el.Key)) continue;

                            this.dataGridView.Rows[i].SetValues(name, "[メッセージが削除されました]",
                                time.ToString("H:mm:ss"), sender);
                            this.dataGridView.Rows[i].Cells[1].Style = StyleDeleted;
                            this._alreadyDeletedIds.Add(el.Key);
                        }
                    }
                }

                


                //Log("InvokeRequired: " + this.InvokeRequired);
                if (this.InvokeRequired)
                    this.BeginInvoke((Action) (() => AddRows(col)));
                else
                    AddRows(col);
                //Log("added all row(s).");
                this._messageIdsOld.AddRange(this._messagesIdsDiff);
                this._messagesIdsDiff.Clear();
            }
            catch (Exception ex)
            {
                Log(ex);
            }

            try
            {
                if (DateTime.Now.Second % 5 == 0)
                {
                    var req = _youtube.Videos.List("snippet");
                    req.Id = this._videoId;
                    var title = req.Execute().Items.FirstOrDefault()?.Snippet.Title;
                    this.BeginInvoke(new Action(() => {
                        label1.Text = title;
                        var source2 =
                            this._webclient.DownloadString("https://www.youtube.com/live_stats?v=" + _videoId);
                        this.label3.Text = $"視聴者数　{int.Parse(source2):#,0}";
                    }));
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }

            this._first = false;
        }

        private static DataGridViewCellStyle SuperChatStyle(int yen)
        {
            var color = Color.Red;
            if (yen < 200) color = Color.DodgerBlue;
            else if (yen < 500) color = Color.DeepSkyBlue;
            else if (yen < 1000) color = Color.LightGreen;
            else if (yen < 5000) color = Color.Orange;
            else if (yen < 10000) color = Color.Magenta;
            return new DataGridViewCellStyle {
                ForeColor = Color.Black,
                BackColor = color
            };
        }

        private DataGridViewRow GetNewRows(LiveChatMessage value)
        {
            var message_sender = value.AuthorDetails?.DisplayName; // ユーザー名
            var message_sender_id = value.AuthorDetails?.ChannelId ?? value.Snippet.AuthorChannelId; // コメント投稿者のID
            var message_text =
                value.Snippet.TextMessageDetails?.MessageText ??
                value.Snippet.SuperChatDetails?.UserComment ??
                "(メッセージはありません)"; // コメント
            var message_id = value.Id; // コメントのID
            var time = (DateTime) value.Snippet.PublishedAt; // 投稿時刻
            var superChatAmount = (int?) (value.Snippet.SuperChatDetails?.AmountMicros / 1000 / 1000) ?? 0;
            var isSuperChatComment = value.Snippet.Type == "superChatEvent";
            var isOwner = value.AuthorDetails?.IsChatOwner == true;
            var isModerator = value.AuthorDetails?.IsChatModerator == true;
            var isOwnerOrModerator = isOwner || isModerator;
            var isSponser = !isOwnerOrModerator && value.AuthorDetails?.IsChatSponsor == true;

            var name = "(削除済み)";
            if (message_sender_id != null)
            {
                //コメント受信時の処理
                this._kotehan.TryGetValue(message_sender_id, out name);
                if (name == null)
                {
                    var match = this._regex.Match(message_text);
                    if (match.Success)
                    {
                        var newname = match.Groups[2].Value;
                        this._kotehan.Add(message_sender_id, newname);
                        //this._kotehanNew = true;
                        name = newname;
                    }
                }
            }


            if (!this._first && this.棒読みちゃん読み上げToolStripMenuItem.Checked &&
                !(isOwnerOrModerator ? this.bouyomi2_0 : this.bouyomi1_0).Checked)
            {
                short voice = 0;
                if ((isOwnerOrModerator ? this.bouyomi2_1 : this.bouyomi1_1).Checked)
                    voice = 1;
                else if ((isOwnerOrModerator ? this.bouyomi2_2 : this.bouyomi1_2).Checked)
                    voice = 2;
                else if ((isOwnerOrModerator ? this.bouyomi2_3 : this.bouyomi1_3).Checked) voice = 5;

                var trigger = (isOwnerOrModerator ? this.bouyomi2_0 : this.bouyomi1_0).Checked ||
                              message_text.StartsWith("/");
                if (!trigger)
                {
                    if (isOwnerOrModerator)
                        Bouyomi(message_text, voice);
                    else
                        Bouyomi(message_text, voice);
                }
            }

            if (isSuperChatComment)
                message_text = $"【{value.Snippet.SuperChatDetails?.AmountDisplayString}】{message_text}";
            var data = new object[]
                {name ?? message_sender, message_text, time.ToString("H:mm:ss"), message_sender};

            var row = new DataGridViewRow();
            row.CreateCells(this.dataGridView);
            row.SetValues(data);
            //// モデレーターのときに赤文字にする
            //for (var i = 0; i < row.Cells.Count; i++) {
            //    row.Cells[i].Style.SelectionForeColor =
            //        isOwnerOrModerator && i == 1 ? Color.Red : SystemColors.ControlText;
            //    row.Cells[i].Style.SelectionBackColor = Color.Transparent;
            //}

            if (isSuperChatComment) row.Cells[1].Style = SuperChatStyle(superChatAmount);
            else if (isOwner) row.Cells[1].Style = StyleOwner;
            else if (isModerator) row.Cells[1].Style = StyleModerator;
            else if (isSponser) row.Cells[1].Style = StyleSponser;
            else row.Cells[1].Style = StyleNormal;
            row.Height = 18;
            if (_messages.ContainsKey(message_id))
            {
                Log($"(メッセージが重複しています){message_text} ID:{message_id} time:{time:HH:mm:ss}");
                return null;
            }

            Log($"(新規メッセージ)[{name ?? message_sender}|{message_sender_id}" +
                (isOwnerOrModerator ? " (Mod)" : "") +
                $"]{message_text}");
            this._messages.Add(message_id,
                (message_sender, message_sender_id, name,
                    isOwnerOrModerator, message_text, time, message_sender));

            return row;
        }

        private void AddRows(IEnumerable<DataGridViewRow> coll)
        {
            try
            {
                var col = coll.Where(x => x != null).ToArray();
                //Log("new rows: " + col.Count);
                if (!col.Any()) return;
                this.dataGridView.Rows.AddRange(col);
                this.dataGridView.FirstDisplayedScrollingRowIndex = this.dataGridView.Rows.Count - 1;

            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void EditUser(object sender, EventArgs e)
        {
            var (id, senderId, _, _, _, _, _) = _messages.ElementAt(_mouseLocation.RowIndex).Value;
            this._kotehan.TryGetValue(senderId, out var senderName);
            var edit = new EditUserForm(id, senderId, senderName);

            if (edit.ShowDialog() != DialogResult.OK) return;
            if (senderName != null)
            {
                Log($"kotehan Edited: {this._kotehan[senderId]} to {edit.SetName}");
                this._kotehan[senderId] = edit.SetName;
            }
            else
            {
                Log($"kotehan Added: {edit.SetName}");
                this._kotehan.Add(senderId, edit.SetName);
            }

            //this._kotehanNew = true;
        }

        private void CopyComment(object sender, EventArgs e)
            => Clipboard.SetText(_messages.ElementAt(_mouseLocation.RowIndex).Value.text);

        private async void Block(object sender, EventArgs e)
        {
            try
            {
                var id = _messages.ElementAt(_mouseLocation.RowIndex).Value.senderId;
                var detail = new ChannelProfileDetails {
                    ChannelId = id
                };
                var snippet = sender == this.ブロックするToolStripMenuItem
                    ? new LiveChatBanSnippet {
                        Type = "permanent",
                        LiveChatId = _liveChatId,
                        BannedUserDetails = detail,
                    }
                    : new LiveChatBanSnippet {
                        Type = "temporary",
                        LiveChatId = _liveChatId,
                        BannedUserDetails = detail,
                        BanDurationSeconds = 300
                    };
                var req = _youtube.LiveChatBans.Insert(new LiveChatBan {Snippet = snippet}, "snippet");
                await req.ExecuteAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ブロックに失敗しました。",
                    "YouTubeLiveCommentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(ex);
            }
        }

        private async void SendMessage(object sender, EventArgs e)
        {
            try
            {
                var msg = textBox1.Text;
                if (string.IsNullOrWhiteSpace(msg)) return;
                var req = _youtube.LiveChatMessages.Insert(new LiveChatMessage {
                    Snippet = new LiveChatMessageSnippet {
                        Type = "textMessageEvent",
                        LiveChatId = _liveChatId,
                        TextMessageDetails = new LiveChatTextMessageDetails {
                            MessageText = msg
                        }
                    }
                }, "snippet");
                textBox1.Text = "";
                await req.ExecuteAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("メッセージの送信に失敗しました。",
                    "YouTubeLiveCommentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(ex);
            }
        }

        private async void DeleteMessage(object sender, EventArgs e)
        {
            try
            {
                var req = _youtube.LiveChatMessages.Delete(_messages.ElementAt(_mouseLocation.RowIndex).Key);
                await req.ExecuteAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("メッセージの削除に失敗しました。",
                    "YouTubeLiveCommentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(ex);
            }

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            int bouyomi1 = 0, bouyomi2 = 0;
            if (bouyomi1_1.Checked) bouyomi1 = 1;
            else if (bouyomi1_2.Checked) bouyomi1 = 2;
            else if (bouyomi1_3.Checked) bouyomi1 = 3;

            if (bouyomi2_1.Checked) bouyomi2 = 1;
            else if (bouyomi2_2.Checked) bouyomi2 = 2;
            else if (bouyomi2_3.Checked) bouyomi2 = 3;

            Settings.Default.row1 = dataGridView.Columns[0].Width;
            Settings.Default.row2 = dataGridView.Columns[1].Width;
            Settings.Default.row3 = dataGridView.Columns[2].Width;
            Settings.Default.row4 = dataGridView.Columns[3].Width;
            Settings.Default.form_size = this.Size;
            Settings.Default.bouyomi1 = bouyomi1;
            Settings.Default.bouyomi2 = bouyomi2;
            Settings.Default.bouyomi = 棒読みちゃん読み上げToolStripMenuItem.Checked;
            Settings.Default.hideOnDelete = this.削除時に非表示にするToolStripMenuItem.Checked;
            Settings.Default.Save();

            try
            {
                this.SaveKotehan();
            }
            catch
            {
                MessageBox.Show("コテハンの保存に失敗しました。",
                    "YouTubeLiveCommentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveKotehan()
        {
            Log("コテハン保存中…");
            using (var writer = new StreamWriter(File.OpenWrite("users.csv"), Encoding.UTF8))
                foreach (var dict in this._kotehan)
                    writer.WriteLine($"{dict.Key},{dict.Value}");
            Log("コテハンが保存されました。");
        }

        private async void ConnectButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (string.IsNullOrEmpty(urlTextBox.Text))
            {
                MessageBox.Show("URLを入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (await Connect(this.urlTextBox.Text))
            {
                this.Invoke((Action) (() => {
                    dataGridView.Rows.Clear();
                    _connecting = true;
                    this.connectButton.Enabled = false;
                    this.disconecctButton.Enabled = true;
                    this.label4.Text = "接続中";
                    label4.ForeColor = Color.LimeGreen;
                }));
            }
            else
            {
                this._connecting = false;
            }

            _timer.Enabled = _connecting;
        }

        private void Disconnect(object sender, EventArgs e)
        {
            this._connecting = _timer.Enabled = false;
            this._channelId = this._videoId = null;
            this.label1.Text = this.label3.Text = "";
            this.connectButton.Enabled = true;
            this.disconecctButton.Enabled = false;
            this.label4.Text = "切断中";
            label4.ForeColor = Color.Red;
            this._messageIdsOld.Clear();
            this._messages.Clear();
            Log("切断しました。");
        }

        private async Task<bool> Connect(string url)
        {
            try
            {
                string channelName = null, userName = null;
                switch (url.Length)
                {
                    case 24:
                        _channelId = url;
                        break;
                    case 11:
                        _videoId = url;
                        break;
                    default:
                        Match urlMatch;
                        if ((urlMatch = Regex.Match(url, @".*/watch\?v=([^/]+).*")).Success)
                            _videoId = urlMatch.Groups[1].Value;
                        if ((urlMatch = Regex.Match(url, @".*youtu.be/([^/]+).*")).Success)
                            _videoId = urlMatch.Groups[1].Value;
                        else if ((urlMatch = Regex.Match(url, @"youtube.com/channel/([^/]+).*")).Success)
                            _channelId = urlMatch.Groups[1].Value;
                        else if ((urlMatch = Regex.Match(url, @".*youtube.com/c/([^/]+).*")).Success)
                            channelName = urlMatch.Groups[1].Value;
                        else if ((urlMatch = Regex.Match(url, @".*youtube.com/user/([^/]+).*")).Success)
                            userName = urlMatch.Groups[1].Value;
                        else
                        {
                            MessageBox.Show("URLの形式が正しくありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        break;
                }

                if (_videoId == null)
                {
                    string video_id_stream;
                    try
                    {
                        var vurl =
                            $"https://www.youtube.com/channel/{_channelId}/videos?flow=list&live_view=501&view=2";
                        if (channelName != null)
                            vurl = $"https://www.youtube.com/c/{channelName}/videos?flow=list&live_view=501&view=2";
                        else if (userName != null)
                            vurl = $"https://www.youtube.com/user/{userName}/videos?flow=list&live_view=501&view=2";
                        video_id_stream = await _webclient.DownloadStringTaskAsync(vurl);
                    }
                    catch
                    {
                        MessageBox.Show("指定されたチャンネルは見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    var video_id_match = new Regex("href=\"\\/watch\\?v=(.+?)\"",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(video_id_stream);
                    if (!video_id_match.Success)
                    {
                        MessageBox.Show("ライブが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    var index1 = video_id_match.Value.LastIndexOf('=') + 1;
                    var index2 = video_id_match.Value.LastIndexOf('"');
                    _videoId = video_id_match.Value.Substring(index1, index2 - index1);
                    Log($"VideoID: {_videoId}");

                    var req = _youtube.Videos.List("snippet");
                    req.Id = this._videoId;
                    var title = (await req.ExecuteAsync()).Items.FirstOrDefault()?.Snippet.Title;

                    var source2 =
                        await this._webclient.DownloadStringTaskAsync(
                            "https://www.youtube.com/live_stats?v=" + _videoId);
                    this.BeginInvoke(new Action(() => {
                        this.label1.Text = title;
                        this.label3.Text = $"視聴者数　{int.Parse(source2):#,0}";
                    }));
                }

                var detail1 = _youtube.Videos.List("liveStreamingDetails,statistics");
                detail1.Id = _videoId;
                var exec = await detail1.ExecuteAsync();
                _liveChatId = exec.Items[0].LiveStreamingDetails.ActiveLiveChatId;
                if (_liveChatId == null)
                {
                    MessageBox.Show("このライブ ストリームではチャットは無効です。", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                Log($"LiveChatID: {_liveChatId}");
            }
            catch
            {
                MessageBox.Show("何らかのエラーが発生しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private static void Bouyomi(string message, short voice = 1, short volume = -1, short speed = -1,
            short tone = -1)
        {
            try
            {
                using (var bouyomiClient = new TcpClient("localhost", 50001))
                {
                    try
                    {
                        var @byte = Encoding.UTF8.GetBytes(message);
                        using (var ns = bouyomiClient.GetStream())
                            using (var bw = new BinaryWriter(ns))
                            {
                                bw.Write((short) 1);
                                bw.Write(speed);
                                bw.Write(tone);
                                bw.Write(volume);
                                bw.Write(voice);
                                bw.Write((short) 0);
                                bw.Write(@byte.Length);
                                bw.Write(@byte);
                            }
                    }
                    catch (Exception ex)
                    {
                        Log(ex);
                    }
                }
            }
            catch
            {
                //
            }

            //_bouyomiLast = message;
        }

        private void ShowKotehanWindow(object sender, EventArgs e)
        {
            var form = new KotehansForm(this._kotehan);
            if (form.ShowDialog() != DialogResult.OK) return;
            this._kotehan.Clear();
            this._kotehan.AddRange(form.Values);
        }

        private void OpenLive(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_videoId))
                Process.Start("https://youtu.be/" + _videoId);
        }

        private static void Log(object o) => Log(o.ToString());

        private static void Log(string s)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.ff}]{s}");
        }
    }
}