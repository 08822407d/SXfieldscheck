namespace SXfieldscheck
{
	partial class FrmMain
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.tbx_inputDIR = new System.Windows.Forms.TextBox();
			this.btn_inputDIR = new System.Windows.Forms.Button();
			this.tbx_outputDIR = new System.Windows.Forms.TextBox();
			this.btn_outputDIR = new System.Windows.Forms.Button();
			this.btn_start = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbx_inputDIR
			// 
			this.tbx_inputDIR.AllowDrop = true;
			this.tbx_inputDIR.Location = new System.Drawing.Point(165, 22);
			this.tbx_inputDIR.Name = "tbx_inputDIR";
			this.tbx_inputDIR.Size = new System.Drawing.Size(434, 25);
			this.tbx_inputDIR.TabIndex = 3;
			// 
			// btn_inputDIR
			// 
			this.btn_inputDIR.Location = new System.Drawing.Point(21, 22);
			this.btn_inputDIR.Name = "btn_inputDIR";
			this.btn_inputDIR.Size = new System.Drawing.Size(126, 25);
			this.btn_inputDIR.TabIndex = 2;
			this.btn_inputDIR.Text = "选择输入文件夹";
			this.btn_inputDIR.UseVisualStyleBackColor = true;
			this.btn_inputDIR.Click += new System.EventHandler(this.btn_inputDIR_Click);
			// 
			// tbx_outputDIR
			// 
			this.tbx_outputDIR.AllowDrop = true;
			this.tbx_outputDIR.Location = new System.Drawing.Point(165, 75);
			this.tbx_outputDIR.Name = "tbx_outputDIR";
			this.tbx_outputDIR.Size = new System.Drawing.Size(434, 25);
			this.tbx_outputDIR.TabIndex = 5;
			// 
			// btn_outputDIR
			// 
			this.btn_outputDIR.Location = new System.Drawing.Point(21, 75);
			this.btn_outputDIR.Name = "btn_outputDIR";
			this.btn_outputDIR.Size = new System.Drawing.Size(126, 25);
			this.btn_outputDIR.TabIndex = 4;
			this.btn_outputDIR.Text = "选择输出文件夹";
			this.btn_outputDIR.UseVisualStyleBackColor = true;
			this.btn_outputDIR.Click += new System.EventHandler(this.btn_outputDIR_Click);
			// 
			// btn_start
			// 
			this.btn_start.Location = new System.Drawing.Point(165, 130);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(108, 27);
			this.btn_start.TabIndex = 6;
			this.btn_start.Text = "开始处理";
			this.btn_start.UseVisualStyleBackColor = true;
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(345, 130);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(108, 27);
			this.btn_cancel.TabIndex = 7;
			this.btn_cancel.Text = "取消";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(629, 183);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_start);
			this.Controls.Add(this.tbx_outputDIR);
			this.Controls.Add(this.btn_outputDIR);
			this.Controls.Add(this.tbx_inputDIR);
			this.Controls.Add(this.btn_inputDIR);
			this.Name = "FrmMain";
			this.Text = "字段检查";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbx_inputDIR;
		private System.Windows.Forms.Button btn_inputDIR;
		private System.Windows.Forms.TextBox tbx_outputDIR;
		private System.Windows.Forms.Button btn_outputDIR;
		private System.Windows.Forms.Button btn_start;
		private System.Windows.Forms.Button btn_cancel;
	}
}

