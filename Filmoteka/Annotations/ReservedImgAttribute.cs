using System.ComponentModel.DataAnnotations;
namespace Filmoteka.Annotations
{
    public class ReservedImgAttribute : ValidationAttribute
    {
        private static string[] myReservedImg;

        public ReservedImgAttribute(string[] Imgs)
        {
            myReservedImg = Imgs;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string temp = value.ToString();
                for (int i = 0; i < myReservedImg.Length; i++)
                {
                    if (temp == myReservedImg[i])
                        return false;
                }
            }
            return true;

        }
    }
}
