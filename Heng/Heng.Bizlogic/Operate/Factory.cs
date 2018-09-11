
using Heng.Bizlogic.Operate.Check;
using Heng.Bizlogic.Operate.Dialog;
using Heng.Bizlogic.Operate.Fight;
using Heng.Bizlogic.Operate.Move;
using Heng.Bizlogic.Operate.ToolSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Heng.Bizlogic.Operate
{
    public static class Factory
    {
        public static Dictionary<string, IMove> dic_move = new Dictionary<string, IMove>();
        private static Dictionary<string, IFight> dic_fight = new Dictionary<string, IFight>();
        private static Dictionary<string, ICheck> dic_check = new Dictionary<string, ICheck>();
        private static Dictionary<string, IToolSkill> dic_ts = new Dictionary<string, IToolSkill>();
        private static Dictionary<string, IDialog> dic_dialog = new Dictionary<string, IDialog>();

        public static IDialog GetDialogInstance(string type)
        {
            if (dic_dialog.Count == 0)
            {
                InitInstance();
            }
            try
            {
                if (dic_dialog.ContainsKey(type))
                {
                    return dic_dialog[type];
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }


        public static IToolSkill GetToolSkillInstance(string type)
        {
            if (dic_ts.Count == 0)
            {
                InitInstance();
            }
            try
            {
                if (dic_ts.ContainsKey(type))
                {
                    return dic_ts[type];
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public static IMove GetMoveInstance(string type)
        {
            if (dic_move.Count == 0)
            {
                InitInstance();
            }
            try
            {
                if (dic_move.ContainsKey(type))
                {
                    return dic_move[type];
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }


        public static IFight GetFightInstance(string type)
        {
            if (dic_fight.Count == 0)
            {
                InitInstance();
            }
            try
            {
                if (dic_fight.ContainsKey(type))
                {
                    return dic_fight[type];
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public static ICheck GetCheckInstance(string type)
        {
            if (dic_check.Count == 0)
            {
                InitInstance();
            }
            try
            {
                if (dic_check.ContainsKey(type))
                {
                    return dic_check[type];
                }
            }
            catch (Exception e)
            {

            }
            return null;
        }


        private static void InitInstance()
        {
            dic_move.Clear();
            dic_fight.Clear();
            dic_check.Clear();
            //todo,后续均通过json配置读取
            List<string> listMove = new List<string>() { "长安", "西凉女国", "傲来国", "建邺" };
            List<string> listFight = new List<string>() { "HSJJ" };
            List<string> listCheck = new List<string>() { "SYX" };
            List<string> listTS = new List<string>() { "摄妖香","飞行符"};
            List<string> listDialog = new List<string>() { "老马猴", "建邺超级巫医" };
            string[] DLLNamespaces = { "Heng.Bizlogic.Operate.Move", "Heng.Bizlogic.Operate.Fight", "Heng.Bizlogic.Operate.Check", "Heng.Bizlogic.Operate.ToolSkill", "Heng.Bizlogic.Operate.Dialog" };
            List<string>[] lists = { listMove, listFight, listCheck, listTS };

            for (int i = 0; i < lists.Length; i++)
            {
                //操作类名
                Assembly assembly = null;
                try { assembly = Assembly.Load(DLLNamespaces[i]); }
                catch { }
                Type type;
                foreach (string DataType in lists[i].ToArray())
                {
                    type = null;
                    if (assembly != null)
                    {
                        type = assembly.GetType(DLLNamespaces[i] + "." + DataType.ToString());
                    }
                    object obj = Activator.CreateInstance(type);
                    if (obj == null)
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        dic_move.Add(DataType.ToString(), (IMove)obj);
                    }
                    else if (i == 1)
                    {
                        dic_fight.Add(DataType.ToString(), (IFight)obj);
                    }
                    else if (i == 2)
                    {
                        dic_check.Add(DataType.ToString(), (ICheck)obj);
                    }
                    else if (i == 3)
                    {
                        dic_ts.Add(DataType.ToString(), (IToolSkill)obj);
                    }
                    else if (i == 3)
                    {
                        dic_dialog.Add(DataType.ToString(), (IDialog)obj);
                    }
                }
                assembly = null;
            }
        }
    }
}