using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kapitel3
{
    class Assets
    {
        private ArrayList pbList = new ArrayList();

        private PictureBox ballPB = new PictureBox();
        private PictureBox paddlePB = new PictureBox();
        private PictureBox backgroundPB = new PictureBox();
        
        private string ballImg = "https://i.redd.it/dbacqs29tpj61.png";
        private string paddleImg = "https://i.redd.it/dbacqs29tpj61.png";
        private string backgroundImg = "https://i.redd.it/dbacqs29tpj61.png";

        public Assets()
        {
            ballPB.ImageLocation = ballImg;
            paddlePB.ImageLocation = ballImg;
            pbList.Add(ballPB);
            pbList.Add(paddlePB);
            pbList.Add(backgroundImg);
            foreach(PictureBox pb in pbList)
                ballPB.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
