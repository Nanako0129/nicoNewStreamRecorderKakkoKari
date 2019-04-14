﻿/*
 * Created by SharpDevelop.
 * User: user
 * Date: 2018/09/21
 * Time: 0:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Data;
using System.Threading.Tasks;

using rokugaTouroku;
using rokugaTouroku.info;

namespace rokugaTouroku.rec
{
	/// <summary>
	/// Description of RecListManager.
	/// </summary>
	public class RecListManager
	{
		public MainForm form;
		public BindingSource recListData;
		public config.config cfg;
		public RecDataGetter rdg;
		 
		public RecListManager(MainForm form, BindingSource recListData, config.config cfg)
		{
			this.form = form;
			this.recListData = recListData;
			this.cfg = cfg;
		}
		public bool add(string t) {
			util.debugWriteLine("rlm add");
            
            var lvid = util.getRegGroup(t, "(lv\\d+(,\\d+)*)");
			//util.setLog(cfg, lv);
			
			var url = "";
			if (lvid != null) {
<<<<<<< HEAD
				url = "https://live2.nicovideo.jp/watch/" + lvid;
=======
				url = "http://live2.nicovideo.jp/watch/" + lvid;
>>>>>>> da2ceb1dec9975a74d9e4b0e4bfbb48a1dad3721
			}
//				if (lvid != null) form.urlText.Text = "https://cas.nicovideo.jp/user/77252622/lv313508832";
				
			else {
				MessageBox.Show("not found lvID");
				return false;
			}
				
			var rdg = new RecDataGetter(this);
			var ri = new RecInfo(lvid, t, rdg, form.afterConvertModeList.Text, form.setTsConfig, form.setTimeshiftBtn.Text, form.qualityBtn.Text, form.qualityRank, form.recCommmentList.Text);
			form.addList(ri);
			
			return true;
				
		}
		public void record() {
			if (util.getRegGroup(form.urlText.Text, "(lv\\d+(,\\d+)*)") == null) {
				form.urlText.Text = "";
			} else {
				if (add(form.urlText.Text))
					form.urlText.Text = "";
			}
			
			if (rdg == null) {
				form.recBtn.Text = "録画停止";
				Task.Run(() => {
					rdg = new RecDataGetter(this);
					rdg.rec();
					rdg = null;
					form.Invoke((MethodInvoker)delegate() {
		            	form.recBtn.Text = "録画開始";
		            });
				});
			} else {
				rdg.stopRecording();
				rdg = null;
				form.recBtn.Text = "録画開始";
			}
			
		}
		
	}
}
