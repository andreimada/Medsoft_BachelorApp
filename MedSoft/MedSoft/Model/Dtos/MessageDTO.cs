using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos {
    [Serializable]
    public class MessageDTO {
        private string fromUsername;
        private string toUsername;
        private string text;

        public string FromUsername { get { return fromUsername; } set { fromUsername = value; } }
        public string ToUsername { get { return toUsername; } set { toUsername = value; } }
        public string Text { get { return text; } set { text = value; } }

        public MessageDTO(string fromUsername, string toUsername, string text) {
            this.fromUsername = fromUsername;
            this.toUsername = toUsername;
            this.text = text;
        }
    }
}
