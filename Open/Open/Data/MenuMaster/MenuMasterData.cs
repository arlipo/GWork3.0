using System;
using System.ComponentModel.DataAnnotations;
using Open.Core;

namespace Open.Data.MenuMaster
{
    public class MenuMasterData : Archetype
    {
        private string menuID, parent_MenuID, menuName, 
            user_Roll, menuFileName, menuURL, use_YN;
        private DateTime dataCreated = DateTime.MinValue;
        private int menuIdentity;

        [Key]
        public int MenuIdentity
        {
            get => getRandomValue(ref menuIdentity);
            set => menuIdentity = value;
        }

        public string MenuID
        {
            get => getString(ref menuID);
            set => menuID = value;
        }

        public string Parent_MenuID
        {
            get => getString(ref parent_MenuID);
            set => parent_MenuID = value;
        }

        public string MenuName
        {
            get => getString(ref menuName);
            set => menuName = value;
        }

        public string User_Roll
        {
            get => getString(ref user_Roll);
            set => user_Roll = value;
        }

        public string MenuFileName
        {
            get => getString(ref menuFileName);
            set => menuFileName = value;
        }

        public string MenuURL
        {
            get => getString(ref menuURL);
            set => menuURL = value;
        }

        public string Use_YN
        {
            get => getString(ref use_YN);
            set => use_YN = value;
        }

        public DateTime DataCreated
        {
            get => getRandomValue(ref dataCreated);
            set => dataCreated = value;
        }
    }
}