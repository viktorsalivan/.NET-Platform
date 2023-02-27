using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SystemMainManager.Controllers
{
   public class Controller
    {
        public void memorycompressionDisable()
        {
            Process pc1 = Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "/command disable-mmagent -memorycompression",
                CreateNoWindow = true,
                UseShellExecute = false
            }); //
        } //memorycompressionFull()
        public void pagecombiningDisable()
        {
            Process pc1 = Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "/command disable-mmagent -pagecombining",
                CreateNoWindow = true,
                UseShellExecute = false
            }); //
        }//pagecombiningFull

        public void applicationprelaunchDisable()
        {
            Process pc1 = Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "/command disable-mmagent -applicationprelaunch",
                CreateNoWindow = true,
                UseShellExecute = false
            }); //
        }//applicationprelaunch

        public void applicationlaunchprefetchingDisable()
        {
            Process pc1 = Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "/command disable-mmagent -applicationLaunchPrefetching",
                CreateNoWindow = true,
                UseShellExecute = false
            }); //
        }//applicationprelaunch

        public void operationapiDisable()
        {
            Process pc1 = Process.Start(new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "/command disable-mmagent -operationapi",
                CreateNoWindow = true,
                UseShellExecute = false
            }); //
        }

 
    } //class Controller

} //END
