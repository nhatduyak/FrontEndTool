namespace SGC_Tool.MyControls
{
    public class DocAttachment
    {
        private string id;
        private string name;
        private string filepath;
        private string docID;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Filepath
        {
            get { return filepath; }
            set { filepath = value; }
        }

        public string DocId
        {
            get { return docID; }
            set { docID = value; }
        }
    }
}
