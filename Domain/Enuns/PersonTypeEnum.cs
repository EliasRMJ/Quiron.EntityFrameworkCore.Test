using Quiron.EntityFrameworkCore.Extensions;

namespace Quiron.EntityFrameworkCore.Enuns
{
    public enum PersonTypeEnum
    {
        [DescriptionEnumAttribute("PF")]
        Phisic = 0,
        [DescriptionEnumAttribute("PJ")]
        Legal = 1
    }
}