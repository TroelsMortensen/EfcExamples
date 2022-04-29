namespace GoodreadsDataGeneration.DataCreation.Generators;

public static class RandomStringGenerator
{
    public static Random rand = new();
    public static string GetRandomString(int maxLength, bool withDots = false)
    {
        int length = rand.Next(maxLength / 3, maxLength);
        int startIdx = rand.Next(0, lorumIpsum.Length - length);
        string substring = lorumIpsum.Substring(startIdx, length);

        string result = string.Concat(substring[0].ToString().ToUpper(), substring.AsSpan(1));
        
        if (!result[^1].Equals('.'))
        {
            if(withDots)
                result += "...";
            
        }
        else if (withDots)
        {
            result += "..";
        }
        
        return result;
    }

    private static readonly string lorumIpsum =
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras condimentum suscipit nisi in pretium. Maecenas luctus nibh at nisl tempor egestas." +
        " Nulla fringilla metus ex, vel tincidunt risus mollis eu. Aliquam et dui lacinia, porttitor lectus vitae, elementum nibh. Pellentesque commodo nibh metus, " +
        "quis vulputate nisl dignissim in. Aenean scelerisque tortor eu elit sagittis sagittis. Vivamus ac felis metus. Nunc quam augue, egestas in pellentesque maximus," +
        " fermentum eleifend ante. Suspendisse ligula eros, elementum mattis urna ac, viverra pellentesque ex. Suspendisse sit amet dignissim massa. Nam ut ligula ac nibh" +
        " ullamcorper egestas feugiat at lacus. Praesent hendrerit pharetra tellus, non elementum dolor commodo nec. Fusce odio quam, faucibus at lorem ut, varius volutpat " +
        "ipsum. Ut elementum ipsum sed nisi convallis hendrerit. Donec tincidunt tempor tortor ac maximus. Mauris dignissim ut diam a mollis. Mauris accumsan vulputate sodales." +
        " Sed gravida a sapien eget fermentum. Etiam ultricies suscipit dui, a gravida odio interdum sit amet. Aliquam pharetra nulla mi, at sagittis orci rutrum non. " +
        "Proin iaculis ultrices viverra. Morbi ultrices risus a sem varius sollicitudin. Sed pulvinar enim ante, ut malesuada neque porta vel. In gravida odio accumsan, " +
        "maximus diam a, sodales lacus. Ut pellentesque elementum est eu convallis. Cras cursus auctor scelerisque. Etiam sagittis nunc id lorem dictum tincidunt. " +
        "Etiam lacinia nulla augue, ut fringilla quam placerat vitae. Maecenas tincidunt mi in quam luctus, eu iaculis ipsum ornare. Cras facilisis condimentum mollis. " +
        "Donec accumsan orci ut dolor viverra gravida. Vestibulum congue euismod lectus non suscipit. In semper malesuada dui ut sodales. Proin porta mauris erat, congue " +
        "condimentum nunc cursus vitae. Quisque nisl lectus, convallis id eros nec, tincidunt aliquam purus. Vestibulum fermentum lorem elit, at luctus tortor mattis eget. " +
        "In pellentesque arcu a tempus condimentum. Morbi venenatis eros sem, in tristique nibh faucibus sed. Vestibulum ipsum velit, laoreet at accumsan et, porta ut arcu." +
        " Aliquam nunc nisi, venenatis finibus justo a, posuere suscipit arcu. Vestibulum ac venenatis augue. Vestibulum semper pulvinar augue vel egestas. Mauris lorem odio, " +
        "auctor et purus in, tincidunt fermentum erat. Donec massa orci, mattis nec nulla eu, mollis egestas nisl. Sed sit amet pretium elit, a cursus risus. Aenean blandit " +
        "purus non molestie porttitor. Vestibulum iaculis egestas posuere. Nam in augue sit amet eros accumsan tempor id nec leo. Etiam dolor urna, iaculis ut libero vitae, " +
        "blandit pellentesque lectus. Curabitur iaculis metus sed orci vestibulum, ac hendrerit nulla volutpat. Vivamus gravida tristique libero, eget elementum nisl vehicula a. " +
        "Nam eget dui at odio scelerisque consectetur at vel nulla. Donec felis massa, finibus vel vulputate pulvinar, tempus ut magna. Cras viverra est iaculis ligula auctor " +
        "ullamcorper. Sed consectetur nisl non nisl feugiat, nec ullamcorper augue elementum. Curabitur efficitur tincidunt lacus eget hendrerit. Nulla vulputate molestie libero," +
        " at scelerisque purus vestibulum et. Donec est dolor, tincidunt in varius quis, ultricies quis justo. Etiam molestie pharetra feugiat. Nullam tristique lorem in consectetur" +
        " sodales. Nullam eget accumsan eros. Vestibulum ipsum arcu, pretium ac ipsum vitae, scelerisque luctus erat. Nullam facilisis cursus gravida. Sed nisl augue, molestie ac " +
        "efficitur et, faucibus eget nunc. Praesent sit amet tincidunt neque, nec tempus nisi. Sed ipsum elit, luctus et bibendum a, egestas et sem. Proin vitae dapibus nunc, at " +
        "tempor nulla. Pellentesque finibus sem in purus dapibus tempus. Mauris risus nisl, euismod sed tellus non, tempus feugiat tortor. Donec a tristique metus. Nam consectetur " +
        "lectus nec libero fringilla, ac sollicitudin dolor accumsan. Morbi aliquet ullamcorper justo, non rhoncus tortor molestie eu. Sed nunc metus, pharetra ut massa nec," +
        " aliquam porta erat. Nulla sit amet consectetur sapien. Phasellus vel convallis massa. Nullam sed felis sit amet orci sagittis semper. Praesent condimentum ullamcorper " +
        "metus sed euismod. Quisque enim turpis, mattis a massa sit amet, vehicula cursus velit. Cras et felis imperdiet, efficitur eros dictum, vulputate turpis. Suspendisse " +
        "vehicula dui odio, non tristique eros pellentesque vel. Fusce dignissim lectus quis varius semper. Phasellus non est vitae turpis ultrices viverra. Mauris semper " +
        "fringilla ipsum, vitae pharetra mauris tempus at. Proin cursus tortor auctor mollis venenatis. Morbi aliquam tempor justo, at malesuada ligula vulputate nec. Duis " +
        "iaculis odio quis quam condimentum aliquam. Sed volutpat turpis sit amet hendrerit fringilla. In sit amet libero convallis, vulputate mi eu, bibendum quam. Praesent" +
        " in tortor augue. Aenean quis purus efficitur, volutpat lectus id, viverra orci. Etiam aliquet ut sem eu ornare. Integer eros nibh, lacinia in sapien et, luctus " +
        "semper libero. Nunc varius sem sapien, suscipit egestas neque suscipit in. Phasellus tellus erat, semper id ligula quis, blandit sodales diam. Lorem ipsum dolor " +
        "sit amet, consectetur adipiscing elit. Vivamus ante nisi, sagittis vel metus sed, scelerisque malesuada velit. Mauris placerat lacinia lobortis. Nunc vestibulum " +
        "viverra vehicula. Etiam lacinia lorem at nulla mattis, eu consequat enim convallis. Vivamus magna nulla, egestas non ligula ac, auctor consequat purus. Donec " +
        "sagittis, lacus vestibulum vestibulum posuere, dui massa condimentum nibh, id aliquet mauris augue et neque. Sed et nulla vitae urna rutrum aliquam vitae ut " +
        "justo. Integer nisl tortor, pharetra porta velit eget, mattis venenatis orci. Integer sagittis ex non mattis ornare. Vivamus ut euismod nulla. Morbi vel lacus" +
        " mollis risus elementum vulputate. Sed in massa orci. Sed ornare lacus eget erat fermentum, vel dignissim tellus suscipit. Donec enim dui, faucibus non nulla " +
        "vel, placerat suscipit risus. Maecenas accumsan interdum eros, eu blandit justo posuere non. Praesent cursus iaculis congue. Cras blandit a quam viverra egestas. " +
        "Aenean volutpat quam quis fringilla varius. Donec faucibus aliquam auctor. Pellentesque pellentesque, lorem et aliquam sollicitudin, magna lectus ultrices elit," +
        " aliquet porta turpis dolor eget felis. Nunc id velit convallis, dictum nunc vitae, dictum ex. Integer purus lorem, scelerisque bibendum viverra vitae, volutpat " +
        "quis libero. Integer vehicula quam vel odio rhoncus iaculis. In hac habitasse platea dictumst. Curabitur at elit id arcu interdum maximus. Cras commodo viverra " +
        "neque eget iaculis. Nullam maximus nunc nibh, in hendrerit nulla viverra quis. Duis viverra ultricies elit eu dictum. Morbi et sapien fermentum, gravida enim sit" +
        " amet, vulputate arcu. In eu libero ut mauris condimentum fermentum quis non eros. Nulla blandit quam sed aliquet fringilla. Praesent in tincidunt eros. Sed semper" +
        " ac quam a egestas. Vestibulum.";
}