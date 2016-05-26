using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCapture.Lib.config
{
    public class SDKConnectStr
    {
        public static string GetSDKInitXml(string centerHostIp, string cengerHostPort, string accountName, string accountPwd)
        {
            string initXml = "<Message type=\"center\">"
                        + "<Center host=\"" + centerHostIp + "\" port=\"" + cengerHostPort + "\" version=\"3\" ssl=\"0\" />"
                        + "<Access host=\"\" port=\"\" />"
                        + "<Self host=\"172.27.35.3\" />"
                        + "<Catalog url=\"\" />"
                        + "<Account name=\"" + accountName + "\" pswd=\"" + accountPwd + "\" dog=\"\" decrypt=\"\" />"
                        + "</ Message>";
            return initXml;
        }


        public static string GetVedioInitXml(string cameraNaming, string accountNaming,
                                            string accountName, int accountPrivilete, string sessionId,
                                            string centerIp, string centerPort, string accessIp, int accessPort)
        {
            string vedioXml = "<Source type=\"access\">"
                            + "<Camera naming=\"" + cameraNaming + "\" name=\"\" />"
                            + "<Version value=\"1\" />"
                            + "<StreamType value=\"MainStream\">"
                            + "<Source id=\""+sessionId+"\" />"
                            + "<Account naming=\"" + accountNaming + "\" name=\"" + accountName + "\"  "
                            + "privilege=\"" + accountPrivilete + "\" sessionid=\"" + sessionId + "\"/>"
                            + "<Dispatch naming=\"\" name=\"\" />"
                            + "<Center ip=\"" + centerIp + "\" port=\"" + centerPort + "\" />"
                            + "<Access ip=\"" + accessIp + "\" port=\"" + accessPort + "\" />"
                            + "<Record cachepath=\"\" second=\"1\" />"
                            + "<SourceStreamCB value=\"0\">"
                            + "</Source>";
            return vedioXml;
        }
    }
}
