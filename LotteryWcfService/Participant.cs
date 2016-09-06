using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary
{

    [DataContract]
    public class Participant
    {
        [DataMember]
        public int idParticipant 
        {
            get { return idParticipant; }
            set { idParticipant = value; }
        }

        [DataMember]
        public string nameParticipant
        {
            get { return nameParticipant; }
            set { nameParticipant = value; }
        }

        [DataMember]
        public int isWinner
        {
            get { return isWinner; }
            set { isWinner = value; }
        }
    }
}
