using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Lib.Core
{
   public class FileLog
    {
        private string log_file_path = null;
        public FileLog()
        {
            log_file_path = null;
        }

        public FileLog(string filePath)
        {
            log_file_path = filePath;
        }

        /// <summary>
        /// 获取或设置日志文件的路径
        /// </summary>
        public string FilePath
        {
            get
            {
                return log_file_path;
            }
            set
            {
                log_file_path = value;
            }
        }

        /// <summary>
        /// 写日志,文件的形式保存到本地
        /// </summary>
        /// <param name="logfile"></param>
        /// <returns></returns>
        public void WriteLog(string logfile)
        {
            StreamWriter sw = null;
            try
            {
                if (log_file_path != null)
                {
                    sw = new StreamWriter(log_file_path, true, System.Text.Encoding.Default);
                    sw.WriteLine(System.DateTime.Now.ToShortTimeString() + " : " + logfile);
                    sw.Close();
                    sw = null;
                }
            }
            catch (Exception) { }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
}
