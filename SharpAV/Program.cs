using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpAV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"   _____ _                         __      __");
            Console.WriteLine(@"  / ____| |                       /\ \    / /");
            Console.WriteLine(@" | (___ | |__   __ _ _ __ _ __   /  \ \  / / ");
            Console.WriteLine(@"  \___ \| '_ \ / _` | '__| '_ \ / /\ \ \/ /  ");
            Console.WriteLine(@"  ____) | | | | (_| | |  | |_) / ____ \  /   ");
            Console.WriteLine(@" |_____/|_| |_|\__,_|_|  | .__/_/    \_\/    ");
            Console.WriteLine(@"                         | |                 ");
            Console.WriteLine(@"  v1.0.0                 |_|                 "+"\r\n");
            AVDetection();
        }
        public static void AVDetection()
        {
            Dictionary<string, string> av_list = new Dictionary<string, string>();
            av_list.Add("d_safe_manage.exe", "d盾");
            av_list.Add("d_manage.exe", "d盾");
            av_list.Add("pc.exe", "云锁客户端");
            av_list.Add("yunsuo_agent_service.exe", "云锁服务端");
            av_list.Add("yunsuo_agent_daemon.exe", "云锁服务端");
            av_list.Add("gov_defence_daemon.exe", "govdefence(网防g01)");
            av_list.Add("gov_defence_service.exe", "govdefence(网防g01)");
            av_list.Add("aliyundun.exe", "阿里云盾");
            av_list.Add("aliyundunupdate.exe", "阿里云盾");
            av_list.Add("aliyun_assist_service.exe", "阿里云盾");
            av_list.Add("360websafe.exe", "360主机卫士");
            av_list.Add("qhsrv.exe", "360主机卫士");
            av_list.Add("qhwebshellguard.exe", "360主机卫士");
            av_list.Add("cloudhelper.exe", "安全狗");
            av_list.Add("safedogtray.exe", "安全狗");
            av_list.Add("safedogguardcenter.exe", "安全狗");
            av_list.Add("safedogupdatecenter.exe", "安全狗");
            av_list.Add("safedogsiteapache.exe", "网站安全狗(apache)");
            av_list.Add("safedogsiteiis.exe", "网站安全狗(iis)");
            av_list.Add("safedogserverui.exe", "服务器安全狗");
            av_list.Add("hws.exe", "护卫神·入侵防护系统");
            av_list.Add("hwsd.exe", "护卫神·入侵防护系统");
            av_list.Add("hws_ui.exe", "护卫神·入侵防护系统");
            av_list.Add("hwspanel.exe", "护卫神·入侵防护系统");
            av_list.Add("hipsdaemon.exe", "火绒安全软件");
            av_list.Add("hipstray.exe", "火绒安全软件");
            av_list.Add("hipslog.exe", "火绒安全软件");
            av_list.Add("hipsmain.exe", "火绒安全软件");
            av_list.Add("usysdiag.exe", "火绒安全软件");
            av_list.Add("wsctrl.exe", "火绒安全软件");
            av_list.Add("qqpcrtp.exe", "腾讯电脑管家");
            av_list.Add("qqpctray.exe", "腾讯电脑管家");
            av_list.Add("qqpcnetflow.exe", "腾讯电脑管家");
            av_list.Add("qqpcrealtimespeedup.exe", "腾讯电脑管家");
            av_list.Add("360sd.exe", "360杀毒");
            av_list.Add("360rp.exe", "360杀毒");
            av_list.Add("360safe.exe", "360安全卫士");
            av_list.Add("360tray.exe", "360实时保护");
            av_list.Add("liveupdate360.exe", "360更新程序");
            av_list.Add("zhudongfangyu.exe", "360主动防御");
            av_list.Add("safeboxtray", "360保险箱保护程序");
            av_list.Add("360safebox.exe", "360保险箱主程序");
            av_list.Add("360skylarsvc.exe", "360天擎终端安全管理系统");
            av_list.Add("savmain.exe", "sophos杀毒");
            av_list.Add("savprogress.exe", "sophos杀毒");
            av_list.Add("mbam.exe", "malwarebytes杀毒");
            av_list.Add("mbamtray.exe", "malwarebytes杀毒");
            av_list.Add("mbamservice.exe", "malwarebytes杀毒");
            av_list.Add("tmbmsrv.exe", "pc-cillin趋势反病毒");
            av_list.Add("ntrtscan.exe", "pc-cillin趋势反病毒");
            av_list.Add("vstskmgr.exe", "mcafee(麦咖啡)");
            av_list.Add("mcshield.exe", "mcafee(麦咖啡)");
            av_list.Add("mfevtps.exe", "mcafee(麦咖啡)");
            av_list.Add("mfeann.exe", "mcafee(麦咖啡)");
            av_list.Add("tbmon.exe", "mcafee(麦咖啡)");
            av_list.Add("shstat.exe", "mcafee(麦咖啡)");
            av_list.Add("mctray.exe", "mcafee(麦咖啡)");
            av_list.Add("udaterui.exe", "mcafee(麦咖啡)");
            av_list.Add("naprdmgr.exe", "mcafee(麦咖啡)");
            av_list.Add("engineserver.exe", "mcafee(麦咖啡)");
            av_list.Add("frameworkservice.exe", "mcafee(麦咖啡)");
            av_list.Add("avk.exe", "gdata安全防护软件");
            av_list.Add("gdscan.exe", "gdata安全防护软件");
            av_list.Add("avkwctl.exe", "gdata安全防护软件");
            av_list.Add("avkcl.exe", "gdata安全防护软件");
            av_list.Add("avkproxy.exe", "gdata安全防护软件");
            av_list.Add("avkbackupservice.exe", "gdata安全防护软件");
            av_list.Add("ccevtmgr.exe", "symantec(赛门铁克)");
            av_list.Add("ccsetmgr.exe", "symantec(赛门铁克)");
            av_list.Add("ccsvchst.exe", "symantec(赛门铁克) 或 norton诺顿杀毒");
            av_list.Add("rtvscan.exe", "symantec(赛门铁克) 或 norton诺顿杀毒");
            av_list.Add("smc.exe", "symantec(赛门铁克)");
            av_list.Add("smcgui.exe", "symantec(赛门铁克)");
            av_list.Add("snac.exe", "symantec(赛门铁克)");
            av_list.Add("msmpeng.exe", "windows defender");
            av_list.Add("nissrv.exe", "windows defender");
            av_list.Add("mssense.exe", "windows defender");
            av_list.Add("msseces.exe", "windows defender");
            av_list.Add("mpcmdrun.exe", "windows defender");
            av_list.Add("avp.exe", "kaspersky(卡巴斯基)");
            av_list.Add("kavfs.exe", "kaspersky(卡巴斯基)");
            av_list.Add("klnagent.exe", "kaspersky(卡巴斯基)");
            av_list.Add("kavtray.exe", "kaspersky(卡巴斯基)");
            av_list.Add("kavfswp.exe", "kaspersky(卡巴斯基)");
            av_list.Add("ekrn.exe", "eset nod32防毒");
            av_list.Add("egui.exe", "eset nod32防毒");
            av_list.Add("eshasrv.exe", "eset nod32防毒");
            av_list.Add("eguiproxy.exe", "eset nod32防毒");
            av_list.Add("avg.exe", "avg杀毒");
            av_list.Add("avgwdsvc.exe", "avg杀毒");
            av_list.Add("avastui.exe", "avast!5主程序");
            av_list.Add("ashdisp.exe", "avast网络安全");
            av_list.Add("clamtray.exe", "clemwin free antivirus");
            av_list.Add("clamscan.exe", "clemwin free antivirus");
            av_list.Add("avcenter.exe", "avira(小红伞)");
            av_list.Add("avguard.exe", "avira(小红伞)");
            av_list.Add("avgnt.exe", "avira(小红伞)");
            av_list.Add("sched.exe", "avira(小红伞)");
            av_list.Add("bddownloader.exe", "百度卫士");
            av_list.Add("baidusafetray.exe", "百度卫士");
            av_list.Add("baiduansvx.exe", "百度卫士-主进程");
            av_list.Add("baidusd.exe", "百度杀毒-主程序");
            av_list.Add("baidusdsvc.exe", "百度杀毒-服务进程");
            av_list.Add("baidusdtray.exe", "百度杀毒-托盘进程");
            av_list.Add("f-prot.exe", "f-prot杀毒");
            av_list.Add("vba32lder.exe", "vb32杀毒");
            av_list.Add("k7tsecurity.exe", "k7杀毒");
            av_list.Add("iptray.exe", "immunet杀毒");
            av_list.Add("cmctrayicon.exe", "cmc杀毒");
            av_list.Add("bkavservice.exe", "bkav杀毒");
            av_list.Add("nspupsvc.exe", "nprotect杀毒");
            av_list.Add("a2guard.exe", "a-squared杀毒");
            av_list.Add("ad-watch.exe", "lavasoft杀毒");
            av_list.Add("unthreat.exe", "unthreat杀毒");
            av_list.Add("psafesystray.exe", "psafe反病毒");
            av_list.Add("patray.exe", "ahnlab安博士杀毒");
            av_list.Add("v3svc.exe", "ahnlab安博士v3杀毒");
            av_list.Add("cleaner8.exe", "the cleaner杀毒");
            av_list.Add("mongoosagui.exe", "mongoosa杀毒");
            av_list.Add("secenter.exe", "bitdefender杀毒");
            av_list.Add("ayagent.exe", "alyac韩国胶囊杀毒");
            av_list.Add("ksafe.exe", "金山卫士");
            av_list.Add("kvmonxp.exe", "江民杀毒");
            av_list.Add("ravmon.exe", "瑞星杀毒");
            av_list.Add("ravmond.exe", "瑞星杀毒");
            av_list.Add("kxescore.exe", "金山毒霸");
            av_list.Add("kupdata.exe", "金山毒霸");
            av_list.Add("kxetray.exe", "金山毒霸");
            av_list.Add("kwsprotect64.exe", "金山毒霸");
            av_list.Add("ksafetray.exe", "金山卫士");
            av_list.Add("knsdtray.exe", "可牛杀毒");
            av_list.Add("sbamsvc.exe", "vipre杀毒");
            av_list.Add("remupd.exe", "熊猫卫士杀毒");
            av_list.Add("spidernt.exe", "dr.web杀毒");
            av_list.Add("quhlpsvc.exe", "quickheal杀毒");
            av_list.Add("fsavgui.exe", "f-secure冰岛杀毒");
            av_list.Add("f-secure.exe", "f-secure冰岛杀毒");
            av_list.Add("arcatasksservice.exe", "arcavir杀毒");
            av_list.Add("vsserv.exe", "bitdefender比特梵德杀毒");
            av_list.Add("avwatchservice.exe", "virusfighter杀毒");
            av_list.Add("ns.exe", "norton诺顿杀毒");
            av_list.Add("ccapp.exe", "norton诺顿杀毒");
            av_list.Add("vptray.exe", "norton病毒防火墙-盾牌图标程序");
            av_list.Add("npfmntor.exe", "norton杀毒软件相关进程");
            av_list.Add("ccregvfy.exe", "norton杀毒软件自身完整性检查程序");
            av_list.Add("sndsrvc.exe", "symantec shared诺顿邮件防火墙软件");
            av_list.Add("spbbcsvc.exe", "symantec shared诺顿邮件防火墙软件");
            av_list.Add("symlcsvc.exe", "symantec shared诺顿邮件防火墙软件");
            av_list.Add("coranticontrolcenter32.exe", "coranti2012杀毒");
            av_list.Add("cksoftshiedantivirus4.exe", "shield antivirus杀毒");
            av_list.Add("spywareterminatorshield.exe", "spywareterminator杀毒");
            av_list.Add("usbkiller.exe", "u盘杀毒专家");
            av_list.Add("ast.exe", "超级巡警");
            av_list.Add("fortitray.exe", "飞塔");
            av_list.Add("parmor.exe", "木马克星");
            av_list.Add("gg.exe", "巨盾网游安全盾");
            av_list.Add("adam.exe", "绿鹰安全精灵");
            av_list.Add("kpfwtray.exe", "金山网镖");
            av_list.Add("beikesan.exe", "贝壳云安全");
            av_list.Add("iparmor.exe.exe", "木马克星");
            av_list.Add("kswebshield.exe", "金山网盾");
            av_list.Add("trojanhunter.exe", "木马猎手");
            av_list.Add("webscanx.exe", "网络病毒克星");
            av_list.Add("ananwidget.exe", "墨者安全专家");
            av_list.Add("pfw.exe", "天网防火墙");
            av_list.Add("cfp.exe", "comodo科摩多");
            av_list.Add("mpmon.exe", "微点主动防御");
            av_list.Add("rfwmain.exe", "瑞星防火墙");
            av_list.Add("sphinx.exe", "sphinx防火墙");
            av_list.Add("vsmon.exe", "zonealarm防火墙");
            av_list.Add("fyfirewall.exe", "风云防火墙");
            av_list.Add("acs.exe", "outpost防火墙");
            av_list.Add("outpost.exe", "outpost防火墙");

            Cmd c = new Cmd();
            string resultStr = c.RunCmd("tasklist /svc");
            resultStr = resultStr.ToLower();

            foreach (KeyValuePair<string, string> kvp in av_list)
            {
                if (resultStr.IndexOf(kvp.Key) > -1)
                {
                    Console.WriteLine(kvp.Key + "：" + kvp.Value);
                }
            }
        }
    }

    /// <summary>
    /// Cmd 的摘要说明。
    /// </summary>
    public class Cmd
    {
        private Process proc = null;
        /// <summary>
        /// 构造方法
        /// </summary>
        public Cmd()
        {
            proc = new Process();
        }
        /// <summary>
        /// 执行CMD语句
        /// </summary>
        /// <param name="cmd">要执行的CMD命令</param>
        public string RunCmd(string cmd)
        {
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            proc.StandardInput.WriteLine(cmd);
            proc.StandardInput.WriteLine("exit");
            string outStr = proc.StandardOutput.ReadToEnd();
            proc.Close();
            return outStr;
        }
    }
}