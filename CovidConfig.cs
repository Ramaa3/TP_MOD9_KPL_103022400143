using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TP_MOD9_103022400143
{
    internal class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public void LoadConfig()
        {
            string json = File.ReadAllText("covid_config.json");
            var data = JsonConvert.DeserializeObject<CovidConfig>(json);

            if (data != null)
            {
                satuan_suhu = data.satuan_suhu;
                batas_hari_deman = data.batas_hari_deman;
                pesan_ditolak = data.pesan_ditolak;
                pesan_diterima = data.pesan_diterima;
            }
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("covid_config.json", json);
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius"){
                satuan_suhu = "fahrenheit";

            } else{
                satuan_suhu = "celcius";
            }
                
                
            

            SaveConfig();
        }
    }
}
