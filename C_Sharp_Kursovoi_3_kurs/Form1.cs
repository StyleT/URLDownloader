using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Kursovoi_3_kurs
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private async void StartButton_Click(object sender, EventArgs e)
		{
			string save_folder="";
			string url_mask= UrlInput.Text;
			LogInput.Text="";
			///
			//Проверка данных
			if(url_mask=="") {
				MessageBox.Show("Enter the mask URL of the resource");
				return;
			}

			//Получаем папку для сохранения файлов
			using (FolderBrowserDialog dialog = new FolderBrowserDialog()){
				dialog.Description = "Folder to save the files";
				dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
				if (dialog.ShowDialog() == DialogResult.OK){
					save_folder = dialog.SelectedPath;
				}else{
					return;
				}
			}
			Log("Save folder: "+save_folder);

			//Блокируем кнопку старта
			StartButton.Enabled= false;

			//Получаем список ссылок из сформированного шаблона
			List<string> parsed_urls= ParseUrl(url_mask);

			//Задаем положение прогрессбара
			loadProgress.Maximum= parsed_urls.Count;
			loadProgress.Value=0;

			//Загружаем ссылки
			foreach(string url in parsed_urls){
				Stream resp= null;
				int request_code = await Task.Run(() => MakeRequest(url, ref resp));
				if(request_code!=200) {
					Log("Request URI: "+url+" [FAILED] Error code: "+request_code+".");
				} else {
					Log("Request URI: "+url+" [OK]");
				}
				string filepath= save_folder+"\\"+MakeName(url)+".html";
				using(Stream file = File.OpenWrite(filepath)) {
					CopyStream(resp, file);
					Log("Saved to: "+filepath);
				}
				loadProgress.Value+=1;
			}

			//Разблокирываем кнопку старта
			StartButton.Enabled= true;
		}

		private List<string> ParseUrl(string input) 
		{
			string pattern = @"%\(.*?\)%";
			List<string> urls= new List<string> { input };
			///
			for(var ij = 0; ij < urls.Count; ij++) {
				foreach(Match match in Regex.Matches(urls[ij], pattern)) {
					List<string> new_urls= new List<string>();
					///
					string input_1= urls[ij].Substring(0, match.Index);
					string input_2= urls[ij].Substring(match.Index+match.Value.Length);

					//Выделяем начальное значение, и конечное
					string match_inner = match.Value.Replace("%(", "").Replace(")%", "");
					string[] inner_arr = match_inner.Split(new Char[]{'-'});
					string start=inner_arr[0], finish= inner_arr[1];

					//Обрабатываем маску согласно её типу
					if(Regex.IsMatch(match_inner, @"^\d+\-\d+$")) {
						int start_int=Convert.ToInt32(start), finish_int= Convert.ToInt32(finish);
						///
						for(var ii = start_int; ii <= finish_int; ii++) {
							new_urls.Add(input_1+ii+input_2);
						}
					} else if(Regex.IsMatch(match_inner, @"^\d\d/\d\d/\d\d\d\d\-\d\d/\d\d/\d\d\d\d$")) {
						DateTime startDate = DateTime.Parse(start);
						DateTime endDate = DateTime.Parse(finish);
						///
						while(DateTime.Compare(startDate, endDate)<=0) {
							new_urls.Add(input_1+startDate.ToString(@"dd\/MM\/yyyy")+input_2);
							startDate= startDate.AddDays(1);
						}
					}

					urls.RemoveAt(ij);
					urls.AddRange(new_urls);
					ij=-1;
					break;
				}
			}
			return urls;
		}

		private int MakeRequest(string url, ref Stream resp) 
		{
			HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(url);
			HttpWReq.Method = "GET";
			HttpWReq.MaximumAutomaticRedirections = 4;
			HttpWebResponse response = (HttpWebResponse)HttpWReq.GetResponse();
			if(response.StatusCode != HttpStatusCode.OK) {
				return (int)response.StatusCode;
			}
			resp= response.GetResponseStream();
			return (int)response.StatusCode;
		}

		private string MakeName(string name)
		{
			foreach(char c in System.IO.Path.GetInvalidFileNameChars()) {
				name = name.Replace(c, '_');
			}
			return name;
		}

		private void CopyStream(Stream input, Stream output)
		{
			byte[] buffer = new byte[8 * 1024];
			int len;
			while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
			{
				output.Write(buffer, 0, len);
			}
		}

		private void Log(string str) 
		{
			LogInput.Text += str+"\r\n";
		}
	}
}
