using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Teahouse.Wpf
{
    class MainLogic
    {
        string url = "http://localhost:53083/api/ExtrasApi/";
        HttpClient client = new HttpClient();

        void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "ExtraResult");
        }

        public List<ExtraViewModel> ApiGetExtras()
        {
            string json = client.GetStringAsync(url + "all").Result;
            var list = JsonConvert.DeserializeObject<List<ExtraViewModel>>(json);
            return list;
        }

        public void ApiDelExtra(ExtraViewModel extra)
        {
            bool success = false;
            if (extra != null)
            {
                string json = client.GetStringAsync(url + "del/" + extra.Id.ToString()).Result;
                JObject obj = JObject.Parse(json);
                success = (bool)obj["OperationResult"];
            }
            this.SendMessage(success);
        }

        bool ApiEditExtra(ExtraViewModel extra, bool isEditing)
        {
            if (extra == null) return false;
            string myUrl = isEditing ? url + "mod" : url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing) postData.Add(nameof(ExtraViewModel.Id), extra.Id.ToString());
            postData.Add(nameof(ExtraViewModel.Category), extra.Category);
            postData.Add(nameof(ExtraViewModel.ExtraName), extra.ExtraName);
            postData.Add(nameof(ExtraViewModel.Price), extra.Price.ToString());
            string json = client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(json);
            return (bool)obj["OperationResult"];
        }

        public void EditExtra(ExtraViewModel extra, Func<ExtraViewModel, bool> editor)
        {
            ExtraViewModel clone = new ExtraViewModel();
            if (extra != null) clone.CopyFrom(extra);
            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (extra != null) success = ApiEditExtra(clone, true);
                else success = ApiEditExtra(clone, false);
            }
            this.SendMessage(success == true);
        }
    }
}
