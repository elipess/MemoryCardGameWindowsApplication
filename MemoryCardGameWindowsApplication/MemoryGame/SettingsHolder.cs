using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public struct SettingsHolder
    {
        private int m_Rows;
        private int m_Cols;
        private bool m_AgainstFriend;
        private string[] m_Names;

        #region Accessors
        public int Rows
        {
            get
            {
                return m_Rows;
            }

            set
            {
                m_Rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return m_Cols;
            }

            set
            {
                m_Cols = value;
            }
        }

        public bool AgainstFriend
        {
            get
            {
                return m_AgainstFriend;
            }

            set
            {
                m_AgainstFriend = value;
            }
        }

        public string[] Names
        {
            get
            {
                return m_Names;
            }

            set
            {
                m_Names = value;
            }
        }
        #endregion
    }
}
