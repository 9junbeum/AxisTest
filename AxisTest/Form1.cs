using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxisTest
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }


        static async Task aaa()
        {
            //① HttpClient 개체 생성
            HttpClient httpClient = new HttpClient();

            //② GetAsync() 메서드 호출
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://root:1@192.168.21.193/axis-cgi/param.cgi?action=list");

            //③ HTML 가져오기
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            //④ 출력
            Console.WriteLine(responseBody);
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {

            string url = "http://root1:1234@192.168.21.193/axis-cgi/mediaclip.cgi?action=play&clip=1&audiooutput=1";  //테스트 사이트
            
            //string url = "http://root:1@192.168.21.193/axis-cgi/param.cgi?action=list";
            string responseText = string.Empty;

            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UseDefaultCredentials = true;
            request.PreAuthenticate = true; 
            System.Net.NetworkCredential netCredential = new System.Net.NetworkCredential("root1", "1234", "192.168.21.193");
            request.Credentials = netCredential;

            //request.Timeout = 30 * 1000; // 30초
            //request.Headers.Add("Authorization", "BASIC SGVsbG8="); // 헤더 추가 방법

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }

            Console.WriteLine(responseText);
        }

        public string make_url(string ID, string PW, string IP)
        {
            //명령어 만들어주는 url
            string result = "";




            return result;

        }


    }
}
