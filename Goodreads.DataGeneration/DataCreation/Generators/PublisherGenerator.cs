using GoodreadsDataGeneration.DataCreation.Models;

namespace GoodreadsDataGeneration.DataCreation.Generators;

public static class PublisherGenerator
{
    public static void AddDataToPublisher(DataBaseModelContainer container)
    {
        GenerateAddresses();

        for (int i = 0; i < container.Publishers.Count; i++)
        {
            PublisherData pub = container.Publishers[i];
            pub.AddressData = addresses[i];
        }
    }

    public static void GenerateAddresses()
    {
        PublisherGenerator.addresses = new();
        string[] addresses = randomAddressesAsString.Split('$');
        int id = 0;
        foreach (string address in addresses)
        {
            var strings = address.Split("#");
            string numberAndStreet = strings[0];
            string cityAndPostal = strings[1];
            string[] houseNumberAndStreet = numberAndStreet.Split(" ");
            string houseNumber = houseNumberAndStreet[0];

            ArraySegment<string> streetArray = new ArraySegment<string>(houseNumberAndStreet, 1, houseNumberAndStreet.Length - 1);
            string street = string.Join(" ", streetArray);

            var split = cityAndPostal.Split(",");

            var cityName = split[0];
            try
            {
                var postCode = split[1];

                AddressData a = new()
                {
                    Id = (++id),
                    Street = street,
                    HouseNumber = houseNumber,
                    CityName = cityName,
                    PostCode = postCode
                };
                PublisherGenerator.addresses.Add(a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }


    private static List<AddressData> addresses;

    // generated from here https://www.randomlists.com/random-addresses?qty=204
    private static readonly string randomAddressesAsString =
        "661 Aspen Ave.#Dekalb, IL 60115$294 Griffin Ave.#Lincoln, NE 68506$388 Boston Drive#Ashburn, VA 20147$7887 North Somerset St.#Fitchburg, MA 01420$2 Birchpond Lane#Santa Clara, CA 95050$90 Carriage St.#Helotes, TX 78023$845 Thomas Street#Abingdon, MD 21009$755 Warren St.#Fargo, ND 58102$7478 Rockwell Street#Reading, MA 01867$9424 W. Thomas Street#Naugatuck, CT 06770$8316 School Ave.#San Jose, CA 95127$221 Westminster St.#Louisville, KY 40207$790 Linden St.#Mahwah, NJ 07430$697 Wayne Rd.#Grayslake, IL 60030$504 E. Henry Ave.#Cordova, TN 38016$266 North Street#Goose Creek, SC 29445$272 Oklahoma Ave.#Bartlett, IL 60103$39 2nd Dr.#Liverpool, NY 13090$74 Brook Drive#Charlotte, NC 28205$9904 Linden Avenue#Goshen, IN 46526$556 South Street#Atlanta, GA 30303$7895 Meadowbrook Street#Stroudsburg, PA 18360$77 Briarwood Drive#Lititz, PA 17543$7 Whitemarsh Lane#Kissimmee, FL 34741$8490 Shady Dr.#East Elmhurst, NY 11369$43 State St.#Dracut, MA 01826$425 West Young Ave.#Tualatin, OR 97062$9899 Hamilton Ave.#Newburgh, NY 12550$161 Fremont St.#Coventry, RI 02816$9 Armstrong Street#Johnston, RI 02919$9 Bayport Street#Huntley, IL 60142$904 Albany Street#Bay Shore, NY 11706$7760 Pilgrim Street#Ogden, UT 84404$4 Young Ave.#La Crosse, WI 54601$49 Lakewood Drive#Warner Robins, GA 31088$7459 Vine Street#Nutley, NJ 07110$8045 Taylor Ave.#Waterloo, IA 50701$592 Augusta Ave.#Circle Pines, MN 55014$19 Howard St.#Yakima, WA 98908$7142 New Saddle Street#Peachtree City, GA 30269$5 S. High Ridge St.#Allison Park, PA 15101$9499 Rosewood Drive#Bardstown, KY 40004$730 Fulton Dr.#Springfield Gardens, NY 11413$386 Willow Dr.#Elkton, MD 21921$76 Rockledge St.#Salisbury, MD 21801$584 Wakehurst Court#Amarillo, TX 79106$54 Branch Drive#New Port Richey, FL 34653$470 Addison St.#Staten Island, NY 10301$45 Clark Dr.#Carol Stream, IL 60188$40 Plumb Branch Ave.#Gloucester, MA 01930$473 Winding Way Street#District Heights, MD 20747$10 North Victoria Lane#Newark, NJ 07103$9923 North Ramblewood St.#Allen Park, MI 48101$56 Lexington Lane#Lincolnton, NC 28092$8279 Inverness Ave.#Frankfort, KY 40601$8806 Andover Street#Lilburn, GA 30047$432 Liberty Road#Saint Charles, IL 60174$90 South Bald Hill Street#Parlin, NJ 08859$4 Grandrose Ave.#Bellmore, NY 11710$44 Grove Lane#Eugene, OR 97402$26 North Beacon Dr.#North Tonawanda, NY 14120$484 Cemetery Ave.#Olney, MD 20832$7765 Sutor St.#Barberton, OH 44203$773 Sycamore Court#Washington, PA 15301$32 Country Club Street#Salt Lake City, UT 84119$8535 Harrison Ave.#Michigan City, IN 46360$99 E. Euclid St.#Chapel Hill, NC 27516$7223 Sunbeam St.#Astoria, NY 11102$9690 Maiden Lane#Mobile, AL 36605$81 West Applegate Drive#Oak Lawn, IL 60453$9070 Wellington Ave.#Hermitage, TN 37076$46 Chapel Dr.#Petersburg, VA 23803$54 Vermont Ave.#Des Plaines, IL 60016$997 W. Water Rd.#Chicago Heights, IL 60411$879 Birchwood Street#Tewksbury, MA 01876$9610 West Lafayette St.#Yuma, AZ 85365$9872 South Cemetery St.#Minneapolis, MN 55406$8899 Ann Lane#Terre Haute, IN 47802$21 Newbridge Dr.#Athens, GA 30605$7776 N. Jefferson Rd.#The Villages, FL 32162$482 Old York Street#Shelbyville, TN 37160$1 Wentworth Ave.#Livingston, NJ 07039$193 Jefferson St.#Lawrence, MA 01841$9341 Carpenter Drive#Lexington, NC 27292$70 Wellington Street#Morgantown, WV 26508$26 S. Primrose Drive#Hopewell, VA 23860$9117 Tanglewood Drive#Northbrook, IL 60062$568 North Harrison Ave.#Mableton, GA 30126$660 North Saxton Dr.#Defiance, OH 43512$42 Longfellow Street#Butler, PA 16001$404 Thatcher Rd.#Queensbury, NY 12804$1 Wentworth Dr.#Santa Cruz, CA 95060$9870 Cedar Swamp Street#Beckley, WV 25801$984 North Sycamore Court#Reston, VA 20191$9033 Bayport Dr.#Savage, MN 55378$9204 Tarkiln Hill Street#Coram, NY 11727$571 East Street#Englishtown, NJ 07726$67 Hillcrest Road#Mount Laurel, NJ 08054$81 South School Road#Middletown, CT 06457$927 Wall Ave.#Casselberry, FL 32707$8000 East Newbridge Court#Beltsville, MD 20705$490 Dunbar St.#Stevens Point, WI 54481$25 West Tower Ave.#Wasilla, AK 99654$44 Henry Smith Street#Avon Lake, OH 44012$771 South Bohemia St.#Neenah, WI 54956$73 Broad Drive#Kalamazoo, MI 49009$7637 Rockaway Street#Glenview, IL 60025$88 Honey Creek St.#Glendora, CA 91740$171 W. Wood St.#Kent, OH 44240$7287 Hill Field Ave.#Sacramento, CA 95820$9580 Fulton Street#Prior Lake, MN 55372$9849 Valley Farms Ave.#Highland, IN 46322$614 Garfield Drive#Hattiesburg, MS 39401$9507 Indian Spring Road#Lansing, MI 48910$486 Summer St.#Forney, TX 75126$8019 W. Hall Street#Auburndale, FL 33823$279 Lafayette Ave.#Tallahassee, FL 32303$67 East Cedarwood Drive#Hudson, NH 03051$73 Mayflower Ave.#Arvada, CO 80003$902 Division Dr.#Worcester, MA 01604$58 Homewood Street#Philadelphia, PA 19111$208 Sunset Ave.#Saint Cloud, MN 56301$88 Linda Ave.#Fairborn, OH 45324$9 Center Street#Egg Harbor Township, NJ 08234$392 Water Street#Plymouth, MA 02360$452 Amerige St.#Kennesaw, GA 30144$829 Heritage Street#Mount Vernon, NY 10550$336 Shub Farm Drive#Winder, GA 30680$82 Corona Ave.#Franklin, MA 02038$449 Beaver Ridge Court#Los Banos, CA 93635$33 Olive Dr.#Ottumwa, IA 52501$8905 Lincoln Street#Shepherdsville, KY 40165$8009 Rock Maple Street#South Portland, ME 04106$82 Arlington St.#Westminster, MD 21157$474 Gonzales Road#Mount Juliet, TN 37122$618 Pawnee Street#Eastlake, OH 44095$76 Pineknoll Circle#New Baltimore, MI 48047$14 S. Whitemarsh St.#Cockeysville, MD 21030$986 Adams Road#Wyandotte, MI 48192$8 Homestead Road#Hanover, PA 17331$73 Spring Rd.#Holbrook, NY 11741$658 South Valley Farms Drive#West Deptford, NJ 08096$5 Blue Spring St.#Lake Zurich, IL 60047$7770 Lakeview St.#Bountiful, UT 84010$97 Albany Dr.#East Stroudsburg, PA 18301$9704 N. Gulf Lane#Bemidji, MN 56601$821 Indian Summer St.#Medina, OH 44256$59 Longfellow Ave.#Malvern, PA 19355$5 Vernon St.#Alexandria, VA 22304$8126 E. Clark Dr.#Fairhope, AL 36532$8059 North High Point Dr.#Elk River, MN 55330$176 Poplar Court#Rockford, MI 49341$7666 S. Cactus Lane#Inman, SC 29349$270 Center Road#Jenison, MI 49428$630 Myrtle Dr.#Milwaukee, WI 53204$928 Pendergast St.#Doylestown, PA 18901$8615 Poplar St.#West Haven, CT 06516$543 Dunbar Drive#Titusville, FL 32780$7251 Theatre St.#Saint Petersburg, FL 33702$959 W. La Sierra St.#Longwood, FL 32779$69 Sierra Ave.#Lindenhurst, NY 11757$46 North Hilltop Street#Livonia, MI 48150$5 Tailwater St.#Melbourne, FL 32904$144 Homewood Ave.#Phoenixville, PA 19460$183 West Drive#Edison, NJ 08817$8013 Greystone Street#Chicago, IL 60621$9529 Division Drive#Manchester Township, NJ 08759$322 Philmont St.#Brandon, FL 33510$33 Gartner Rd.#Fort Lee, NJ 07024$20 West Carriage St.#Satellite Beach, FL 32937$291 W. Redwood St.#Saint Paul, MN 55104$341 Rockland Dr.#Toms River, NJ 08753$83 Littleton Lane#New Britain, CT 06051$5 East Pulaski Lane#Dickson, TN 37055$61 Westminster Avenue#Jupiter, FL 33458$453 North Highland Street#Canandaigua, NY 14424$331 Liberty Road#Atwater, CA 95301$57 NW. Valley St.#Owosso, MI 48867$894 Henry Smith Dr.#Derby, KS 67037$8149 N. Boston St.#Norcross, GA 30092$24 Green Lake Lane#El Dorado, AR 71730$59 Belmont St.#Rockville, MD 20850$666 Thompson Ave.#Emporia, KS 66801$854 Harrison St.#Apple Valley, CA 92307$953 E. Anderson St.#Council Bluffs, IA 51501$531 Alton Street#Rossville, GA 30741$144 Bank Street#Mount Holly, NJ 08060$7601 Winchester Street#Fort Lauderdale, FL 33308$9699 Manchester St.#New Berlin, WI 53151$37 Cedar Lane#Winchester, VA 22601$513 Devon St.#Rochester, NY 14606$70 Glenholme Ave.#Webster, NY 14580$9494 Jackson Street#Monroe, NY 10950$912 S. Oak Valley Ave.#North Brunswick, NJ 08902$886 Linda Rd.#Zanesville, OH 43701$7181 St Louis St.#North Royalton, OH 44133$8923 West William Drive#Avon, IN 46123$3 El Dorado Lane#West Springfield, MA 01089$9636 Rockville Drive#Coatesville, PA 19320$9475 East Cottage Lane#Cambridge, MA 02138$703 Bear Hill St.#Lutherville Timonium, MD 21093$46 North Avenue#Camden, NJ 08105$11 W. Santa Clara Ave.#Saint Albans, NY 11412$93 Parker Street#Hoffman Estates, IL 60169$48 Pierce Rd.#Fullerton, CA 92831$284 North St Louis St.#Drexel Hill, PA 19026$7152 Hartford Street#Ypsilanti, MI 48197$7457 South Smith St.#Griffin, GA 30223$9385 S. Buttonwood Street#Rosemount, MN 55068$7422 Bow Ridge St.#Ephrata, PA 17522$834 Saxon Avenue#North Kingstown, RI 02852$793 Shady St.#Clifton Park, NY 12065$939 N. Cedarwood Lane#Port Saint Lucie, FL 34952$633 Bedford Ave.#Morganton, NC 28655$9684 Trusel Ave.#Bozeman, MT 59715$8293 Talbot Rd.#Germantown, MD 20874$3 Foxrun Dr.#Desoto, TX 75115$378 Mayflower St.#Tuckerton, NJ 08087$57 Second St.#Hopkinsville, KY 42240$9434 Orange St.#Hinesville, GA 31313$8309 Del Monte St.#Pataskala, OH 43062$63 West Branch Drive#Hudsonville, MI 49426$2 Hilldale St.#Bristol, CT 06010$7 Crescent Ave.#Pomona, CA 91768$89 N. Peg Shop Rd.#Alabaster, AL 35007$277 Vernon Circle#Dayton, OH 45420$8362 Wagon St.#South Lyon, MI 48178$30 Warren Rd.#Beachwood, OH 44122$52 Newcastle Drive#Pensacola, FL 32503$28 Liberty Street#Fredericksburg, VA 22405$8353 Squaw Creek Lane#Homestead, FL 33030$31 Charles Lane#Columbia, MD 21044$57 Southampton St.#Lake In The Hills, IL 60156$4 Annadale St.#Quakertown, PA 18951$1 Brickell Street#West Bend, WI 53095$14 Walnut Ave.#Fort Mill, SC 29708$263 Lookout St.#Matthews, NC 28104$26 Briarwood St.#Voorhees, NJ 08043$9420 W. Thatcher St.#Onalaska, WI 54650$930 North Galvin Drive#El Paso, TX 79930$64 South Lilac St.#Aiken, SC 29803$36 Deerfield Street#Vincentown, NJ 08088$192 Dogwood St.#Jackson Heights, NY 11372$8593 East Homestead Dr.#Massapequa Park, NY 11762$48 Walt Whitman Ave.#Sunnyside, NY 11104$9979 Edgemont St.#Silver Spring, MD 20901$956 Mayfield Court#Hendersonville, NC 28792£7683 Walnutwood St.#Lowell, MA 01851$77 Lawrence Circle#Rome, NY 13440$5 Monroe St.#Camp Hill, PA 17011";
}