namespace YouTubeLiveCommentViewer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コテハンを保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.閉じるXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コテハン一覧を表示CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定8SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.棒読みちゃん読み上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.一般コメント声質ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bouyomi1_0 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.bouyomi1_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bouyomi1_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bouyomi1_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.運営コメント声質ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bouyomi2_0 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.bouyomi2_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bouyomi2_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bouyomi2_3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放送ページを開くLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.コメントをコピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.メッセージを削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ブロックするToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.タイムアウトにするToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ユーザー情報編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconecctButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.削除時に非表示にするToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(11, 93);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 21;
            this.dataGridView.Size = new System.Drawing.Size(570, 228);
            this.dataGridView.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 328);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(504, 23);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(522, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "送信";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.表示FToolStripMenuItem,
            this.設定8SToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(594, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.コテハンを保存ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.閉じるXToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // コテハンを保存ToolStripMenuItem
            // 
            this.コテハンを保存ToolStripMenuItem.Name = "コテハンを保存ToolStripMenuItem";
            this.コテハンを保存ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.コテハンを保存ToolStripMenuItem.Text = "コテハンを保存(&S)";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(153, 6);
            // 
            // 閉じるXToolStripMenuItem
            // 
            this.閉じるXToolStripMenuItem.Name = "閉じるXToolStripMenuItem";
            this.閉じるXToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.閉じるXToolStripMenuItem.Text = "閉じる (&X)";
            // 
            // 表示FToolStripMenuItem
            // 
            this.表示FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.コテハン一覧を表示CToolStripMenuItem});
            this.表示FToolStripMenuItem.Name = "表示FToolStripMenuItem";
            this.表示FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.表示FToolStripMenuItem.Text = "表示(&F)";
            // 
            // コテハン一覧を表示CToolStripMenuItem
            // 
            this.コテハン一覧を表示CToolStripMenuItem.Name = "コテハン一覧を表示CToolStripMenuItem";
            this.コテハン一覧を表示CToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.コテハン一覧を表示CToolStripMenuItem.Text = "コテハン一覧を表示 (&N)";
            // 
            // 設定8SToolStripMenuItem
            // 
            this.設定8SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.削除時に非表示にするToolStripMenuItem,
            this.toolStripMenuItem7,
            this.棒読みちゃん読み上げToolStripMenuItem,
            this.toolStripMenuItem3,
            this.一般コメント声質ToolStripMenuItem,
            this.運営コメント声質ToolStripMenuItem});
            this.設定8SToolStripMenuItem.Name = "設定8SToolStripMenuItem";
            this.設定8SToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.設定8SToolStripMenuItem.Text = "設定(&S)";
            // 
            // 棒読みちゃん読み上げToolStripMenuItem
            // 
            this.棒読みちゃん読み上げToolStripMenuItem.CheckOnClick = true;
            this.棒読みちゃん読み上げToolStripMenuItem.Name = "棒読みちゃん読み上げToolStripMenuItem";
            this.棒読みちゃん読み上げToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.棒読みちゃん読み上げToolStripMenuItem.Text = "棒読みちゃん読み上げ";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(213, 6);
            // 
            // 一般コメント声質ToolStripMenuItem
            // 
            this.一般コメント声質ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bouyomi1_0,
            this.toolStripMenuItem5,
            this.bouyomi1_1,
            this.bouyomi1_2,
            this.bouyomi1_3});
            this.一般コメント声質ToolStripMenuItem.Name = "一般コメント声質ToolStripMenuItem";
            this.一般コメント声質ToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.一般コメント声質ToolStripMenuItem.Text = "一般コメント声質";
            // 
            // bouyomi1_0
            // 
            this.bouyomi1_0.Name = "bouyomi1_0";
            this.bouyomi1_0.Size = new System.Drawing.Size(137, 22);
            this.bouyomi1_0.Text = "読み上げなし";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(134, 6);
            // 
            // bouyomi1_1
            // 
            this.bouyomi1_1.Name = "bouyomi1_1";
            this.bouyomi1_1.Size = new System.Drawing.Size(137, 22);
            this.bouyomi1_1.Text = "女声1";
            // 
            // bouyomi1_2
            // 
            this.bouyomi1_2.Name = "bouyomi1_2";
            this.bouyomi1_2.Size = new System.Drawing.Size(137, 22);
            this.bouyomi1_2.Text = "女声2";
            // 
            // bouyomi1_3
            // 
            this.bouyomi1_3.Name = "bouyomi1_3";
            this.bouyomi1_3.Size = new System.Drawing.Size(137, 22);
            this.bouyomi1_3.Text = "中性";
            // 
            // 運営コメント声質ToolStripMenuItem
            // 
            this.運営コメント声質ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bouyomi2_0,
            this.toolStripMenuItem6,
            this.bouyomi2_1,
            this.bouyomi2_2,
            this.bouyomi2_3});
            this.運営コメント声質ToolStripMenuItem.Name = "運営コメント声質ToolStripMenuItem";
            this.運営コメント声質ToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.運営コメント声質ToolStripMenuItem.Text = "運営コメント声質";
            // 
            // bouyomi2_0
            // 
            this.bouyomi2_0.Name = "bouyomi2_0";
            this.bouyomi2_0.Size = new System.Drawing.Size(137, 22);
            this.bouyomi2_0.Text = "読み上げなし";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(134, 6);
            // 
            // bouyomi2_1
            // 
            this.bouyomi2_1.Name = "bouyomi2_1";
            this.bouyomi2_1.Size = new System.Drawing.Size(137, 22);
            this.bouyomi2_1.Text = "女声1";
            // 
            // bouyomi2_2
            // 
            this.bouyomi2_2.Name = "bouyomi2_2";
            this.bouyomi2_2.Size = new System.Drawing.Size(137, 22);
            this.bouyomi2_2.Text = "女声2";
            // 
            // bouyomi2_3
            // 
            this.bouyomi2_3.Name = "bouyomi2_3";
            this.bouyomi2_3.Size = new System.Drawing.Size(137, 22);
            this.bouyomi2_3.Text = "中性";
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.放送ページを開くLToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // 放送ページを開くLToolStripMenuItem
            // 
            this.放送ページを開くLToolStripMenuItem.Name = "放送ページを開くLToolStripMenuItem";
            this.放送ページを開くLToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.放送ページを開くLToolStripMenuItem.Text = "放送ページを開く (&L)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(432, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 25);
            this.label1.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.コメントをコピーToolStripMenuItem,
            this.toolStripMenuItem1,
            this.メッセージを削除ToolStripMenuItem,
            this.ブロックするToolStripMenuItem,
            this.タイムアウトにするToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ユーザー情報編集ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 126);
            // 
            // コメントをコピーToolStripMenuItem
            // 
            this.コメントをコピーToolStripMenuItem.Name = "コメントをコピーToolStripMenuItem";
            this.コメントをコピーToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.コメントをコピーToolStripMenuItem.Text = "コメントをコピー";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // メッセージを削除ToolStripMenuItem
            // 
            this.メッセージを削除ToolStripMenuItem.Name = "メッセージを削除ToolStripMenuItem";
            this.メッセージを削除ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.メッセージを削除ToolStripMenuItem.Text = "メッセージを削除";
            // 
            // ブロックするToolStripMenuItem
            // 
            this.ブロックするToolStripMenuItem.Name = "ブロックするToolStripMenuItem";
            this.ブロックするToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ブロックするToolStripMenuItem.Text = "ブロックする";
            // 
            // タイムアウトにするToolStripMenuItem
            // 
            this.タイムアウトにするToolStripMenuItem.Name = "タイムアウトにするToolStripMenuItem";
            this.タイムアウトにするToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.タイムアウトにするToolStripMenuItem.Text = "タイムアウトにする";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
            // 
            // ユーザー情報編集ToolStripMenuItem
            // 
            this.ユーザー情報編集ToolStripMenuItem.Name = "ユーザー情報編集ToolStripMenuItem";
            this.ユーザー情報編集ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ユーザー情報編集ToolStripMenuItem.Text = "ユーザー情報編集";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "放送URL";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(78, 36);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(328, 23);
            this.urlTextBox.TabIndex = 7;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(412, 35);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(47, 23);
            this.connectButton.TabIndex = 8;
            this.connectButton.Text = "接続";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // disconecctButton
            // 
            this.disconecctButton.Enabled = false;
            this.disconecctButton.Location = new System.Drawing.Point(465, 36);
            this.disconecctButton.Name = "disconecctButton";
            this.disconecctButton.Size = new System.Drawing.Size(47, 23);
            this.disconecctButton.TabIndex = 9;
            this.disconecctButton.Text = "切断";
            this.disconecctButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(518, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "切断中";
            // 
            // 削除時に非表示にするToolStripMenuItem
            // 
            this.削除時に非表示にするToolStripMenuItem.CheckOnClick = true;
            this.削除時に非表示にするToolStripMenuItem.Name = "削除時に非表示にするToolStripMenuItem";
            this.削除時に非表示にするToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.削除時に非表示にするToolStripMenuItem.Text = "コメント削除時に非表示にする";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(213, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(594, 362);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.disconecctButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(610, 226);
            this.Name = "Form1";
            this.Text = "YouTubeLiveCommentViewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表示FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定8SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem メッセージを削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ブロックするToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コメントをコピーToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem タイムアウトにするToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ユーザー情報編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 棒読みちゃん読み上げToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 一般コメント声質ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bouyomi1_1;
        private System.Windows.Forms.ToolStripMenuItem bouyomi1_2;
        private System.Windows.Forms.ToolStripMenuItem bouyomi1_3;
        private System.Windows.Forms.ToolStripMenuItem 運営コメント声質ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bouyomi2_1;
        private System.Windows.Forms.ToolStripMenuItem bouyomi2_2;
        private System.Windows.Forms.ToolStripMenuItem bouyomi2_3;
        private System.Windows.Forms.ToolStripMenuItem bouyomi1_0;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem bouyomi2_0;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem 閉じるXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コテハン一覧を表示CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放送ページを開くLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コテハンを保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconecctButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem 削除時に非表示にするToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
    }
}

