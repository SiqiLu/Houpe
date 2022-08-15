// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Base32Extensions_Should.cs
// CreatedAt        : 2021-06-06
// LastModifiedAt   : 2021-06-06
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Houpe.Foundation.Tests
{
    [TestClass]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class Base32Extensions_Should
    {
        public static readonly string Data =
            @"The unanimous Declaration of the thirteen united States of America, When in the Course of human events, it becomes necessary for one people to dissolve the political bands which have connected them with another, and to assume among the powers of the earth, the separate and equal station to which the Laws of Nature and of Nature's God entitle them, a decent respect to the opinions of mankind requires that they should declare the causes which impel them to the separation.

We hold these truths to be self-evident, that all men are created equal, that they are endowed by their Creator with certain unalienable Rights, that among these are Life, Liberty and the pursuit of Happiness.--That to secure these rights, Governments are instituted among Men, deriving their just powers from the consent of the governed, --That whenever any Form of Government becomes destructive of these ends, it is the Right of the People to alter or to abolish it, and to institute new Government, laying its foundation on such principles and organizing its powers in such form, as to them shall seem most likely to effect their Safety and Happiness. Prudence, indeed, will dictate that Governments long established should not be changed for light and transient causes; and accordingly all experience hath shewn, that mankind are more disposed to suffer, while evils are sufferable, than to right themselves by abolishing the forms to which they are accustomed. But when a long train of abuses and usurpations, pursuing invariably the same Object evinces a design to reduce them under absolute Despotism, it is their right, it is their duty, to throw off such Government, and to provide new Guards for their future security.--Such has been the patient sufferance of these Colonies; and such is now the necessity which constrains them to alter their former Systems of Government. The history of the present King of Great Britain is a history of repeated injuries and usurpations, all having in direct object the establishment of an absolute Tyranny over these States. To prove this, let Facts be submitted to a candid world.

He has refused his Assent to Laws, the most wholesome and necessary for the public good.

He has forbidden his Governors to pass Laws of immediate and pressing importance, unless suspended in their operation till his Assent should be obtained; and when so suspended, he has utterly neglected to attend to them.

He has refused to pass other Laws for the accommodation of large districts of people, unless those people would relinquish the right of Representation in the Legislature, a right inestimable to them and formidable to tyrants only.

He has called together legislative bodies at places unusual, uncomfortable, and distant from the depository of their public Records, for the sole purpose of fatiguing them into compliance with his measures.

He has dissolved Representative Houses repeatedly, for opposing with manly firmness his invasions on the rights of the people.

He has refused for a long time, after such dissolutions, to cause others to be elected; whereby the Legislative powers, incapable of Annihilation, have returned to the People at large for their exercise; the State remaining in the mean time exposed to all the dangers of invasion from without, and convulsions within.

He has endeavoured to prevent the population of these States; for that purpose obstructing the Laws for Naturalization of Foreigners; refusing to pass others to encourage their migrations hither, and raising the conditions of new Appropriations of Lands.

He has obstructed the Administration of Justice, by refusing his Assent to Laws for establishing Judiciary powers.

He has made Judges dependent on his Will alone, for the tenure of their offices, and the amount and payment of their salaries.

He has erected a multitude of New Offices, and sent hither swarms of Officers to harrass our people, and eat out their substance.

He has kept among us, in times of peace, Standing Armies without the Consent of our legislatures.

He has affected to render the Military independent of and superior to the Civil power.

He has combined with others to subject us to a jurisdiction foreign to our constitution, and unacknowledged by our laws; giving his Assent to their Acts of pretended Legislation:

For Quartering large bodies of armed troops among us:

For protecting them, by a mock Trial, from punishment for any Murders which they should commit on the Inhabitants of these States:

For cutting off our Trade with all parts of the world:

For imposing Taxes on us without our Consent:

For depriving us in many cases, of the benefits of Trial by Jury:

For transporting us beyond Seas to be tried for pretended offences

For abolishing the free System of English Laws in a neighbouring Province, establishing therein an Arbitrary government, and enlarging its Boundaries so as to render it at once an example and fit instrument for introducing the same absolute rule into these Colonies:

For taking away our Charters, abolishing our most valuable Laws, and altering fundamentally the Forms of our Governments:

For suspending our own Legislatures, and declaring themselves invested with power to legislate for us in all cases whatsoever.

He has abdicated Government here, by declaring us out of his Protection and waging War against us.

He has plundered our seas, ravaged our Coasts, burnt our towns, and destroyed the lives of our people.

He is at this time transporting large Armies of foreign Mercenaries to compleat the works of death, desolation and tyranny, already begun with circumstances of Cruelty & perfidy scarcely paralleled in the most barbarous ages, and totally unworthy the Head of a civilized nation.

He has constrained our fellow Citizens taken Captive on the high Seas to bear Arms against their Country, to become the executioners of their friends and Brethren, or to fall themselves by their Hands.

He has excited domestic insurrections amongst us, and has endeavoured to bring on the inhabitants of our frontiers, the merciless Indian Savages, whose known rule of warfare, is an undistinguished destruction of all ages, sexes and conditions.

In every stage of these Oppressions We have Petitioned for Redress in the most humble terms: Our repeated Petitions have been answered only by repeated injury. A Prince whose character is thus marked by every act which may define a Tyrant, is unfit to be the ruler of a free people.

Nor have We been wanting in attentions to our Brittish brethren. We have warned them from time to time of attempts by their legislature to extend an unwarrantable jurisdiction over us. We have reminded them of the circumstances of our emigration and settlement here. We have appealed to their native justice and magnanimity, and we have conjured them by the ties of our common kindred to disavow these usurpations, which, would inevitably interrupt our connections and correspondence. They too have been deaf to the voice of justice and of consanguinity. We must, therefore, acquiesce in the necessity, which denounces our Separation, and hold them, as we hold the rest of mankind, Enemies in War, in Peace Friends.

We, therefore, the Representatives of the united States of America, in General Congress, Assembled, appealing to the Supreme Judge of the world for the rectitude of our intentions, do, in the Name, and by Authority of the good People of these Colonies, solemnly publish and declare, That these United Colonies are, and of Right ought to be Free and Independent States; that they are Absolved from all Allegiance to the British Crown, and that all political connection between them and the State of Great Britain, is and ought to be totally dissolved; and that as Free and Independent States, they have full Power to levy War, conclude Peace, contract Alliances, establish Commerce, and to do all other Acts and Things which Independent States may of right do. And for the support of this Declaration, with a firm reliance on the protection of divine Providence, we mutually pledge to each other our Lives, our Fortunes and our sacred Honor.";

        [TestMethod]
        public void HelloWorld_Should()
        {
            Encoding encoding = Encoding.UTF8;

            string source = "Hello World!";

            string expected = "JBSWY3DPEBLW64TMMQQQ====";

            byte[] bytes = encoding.GetBytes(source);
            string actual1 = bytes.EncodeToStringByBase32();

            string actual2 = source.EncodeToStringByBase32();

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);

            CollectionAssert.AreEqual(bytes, expected.DecodeToBytesByBase32());
            Assert.AreEqual(source, expected.DecodeToStringByBase32());
        }

        [TestMethod]
        public void Text_Should()
        {
            Encoding encoding = Encoding.UTF8;

            string source = Data.Replace("\r", "").Replace("\n", "");
            string expected =
                "KRUGKIDVNZQW42LNN52XGICEMVRWYYLSMF2GS33OEBXWMIDUNBSSA5DINFZHIZLFNYQHK3TJORSWIICTORQXIZLTEBXWMICBNVSXE2LDMEWCAV3IMVXCA2LOEB2GQZJAINXXK4TTMUQG6ZRANB2W2YLOEBSXMZLOORZSYIDJOQQGEZLDN5WWK4ZANZSWGZLTONQXE6JAMZXXEIDPNZSSA4DFN5YGYZJAORXSAZDJONZW63DWMUQHI2DFEBYG63DJORUWGYLMEBRGC3TEOMQHO2DJMNUCA2DBOZSSAY3PNZXGKY3UMVSCA5DIMVWSA53JORUCAYLON52GQZLSFQQGC3TEEB2G6IDBONZXK3LFEBQW233OM4QHI2DFEBYG653FOJZSA33GEB2GQZJAMVQXE5DIFQQHI2DFEBZWK4DBOJQXIZJAMFXGIIDFOF2WC3BAON2GC5DJN5XCA5DPEB3WQ2LDNAQHI2DFEBGGC53TEBXWMICOMF2HK4TFEBQW4ZBAN5TCATTBOR2XEZJHOMQEO33EEBSW45DJORWGKIDUNBSW2LBAMEQGIZLDMVXHIIDSMVZXAZLDOQQHI3ZAORUGKIDPOBUW42LPNZZSA33GEBWWC3TLNFXGIIDSMVYXK2LSMVZSA5DIMF2CA5DIMV4SA43IN52WYZBAMRSWG3DBOJSSA5DIMUQGGYLVONSXGIDXNBUWG2BANFWXAZLMEB2GQZLNEB2G6IDUNBSSA43FOBQXEYLUNFXW4LSXMUQGQ33MMQQHI2DFONSSA5DSOV2GQ4ZAORXSAYTFEBZWK3DGFVSXM2LEMVXHILBAORUGC5BAMFWGYIDNMVXCAYLSMUQGG4TFMF2GKZBAMVYXKYLMFQQHI2DBOQQHI2DFPEQGC4TFEBSW4ZDPO5SWIIDCPEQHI2DFNFZCAQ3SMVQXI33SEB3WS5DIEBRWK4TUMFUW4IDVNZQWY2LFNZQWE3DFEBJGSZ3IORZSYIDUNBQXIIDBNVXW4ZZAORUGK43FEBQXEZJAJRUWMZJMEBGGSYTFOJ2HSIDBNZSCA5DIMUQHA5LSON2WS5BAN5TCASDBOBYGS3TFONZS4LJNKRUGC5BAORXSA43FMN2XEZJAORUGK43FEBZGSZ3IORZSYICHN53GK4TONVSW45DTEBQXEZJANFXHG5DJOR2XIZLEEBQW233OM4QE2ZLOFQQGIZLSNF3GS3THEB2GQZLJOIQGU5LTOQQHA33XMVZHGIDGOJXW2IDUNBSSAY3PNZZWK3TUEBXWMIDUNBSSAZ3POZSXE3TFMQWCALJNKRUGC5BAO5UGK3TFOZSXEIDBNZ4SARTPOJWSA33GEBDW65TFOJXG2ZLOOQQGEZLDN5WWK4ZAMRSXG5DSOVRXI2LWMUQG6ZRAORUGK43FEBSW4ZDTFQQGS5BANFZSA5DIMUQFE2LHNB2CA33GEB2GQZJAKBSW64DMMUQHI3ZAMFWHIZLSEBXXEIDUN4QGCYTPNRUXG2BANF2CYIDBNZSCA5DPEBUW443UNF2HK5DFEBXGK5ZAI5XXMZLSNZWWK3TUFQQGYYLZNFXGOIDJORZSAZTPOVXGIYLUNFXW4IDPNYQHG5LDNAQHA4TJNZRWS4DMMVZSAYLOMQQG64THMFXGS6TJNZTSA2LUOMQHA33XMVZHGIDJNYQHG5LDNAQGM33SNUWCAYLTEB2G6IDUNBSW2IDTNBQWY3BAONSWK3JANVXXG5BANRUWWZLMPEQHI3ZAMVTGMZLDOQQHI2DFNFZCAU3BMZSXI6JAMFXGIICIMFYHA2LOMVZXGLRAKBZHKZDFNZRWKLBANFXGIZLFMQWCA53JNRWCAZDJMN2GC5DFEB2GQYLUEBDW65TFOJXG2ZLOORZSA3DPNZTSAZLTORQWE3DJONUGKZBAONUG65LMMQQG433UEBRGKIDDNBQW4Z3FMQQGM33SEBWGSZ3IOQQGC3TEEB2HEYLOONUWK3TUEBRWC5LTMVZTWIDBNZSCAYLDMNXXEZDJNZTWY6JAMFWGYIDFPBYGK4TJMVXGGZJANBQXI2BAONUGK53OFQQHI2DBOQQG2YLONNUW4ZBAMFZGKIDNN5ZGKIDENFZXA33TMVSCA5DPEBZXKZTGMVZCYIDXNBUWYZJAMV3GS3DTEBQXEZJAON2WMZTFOJQWE3DFFQQHI2DBNYQHI3ZAOJUWO2DUEB2GQZLNONSWY5TFOMQGE6JAMFRG63DJONUGS3THEB2GQZJAMZXXE3LTEB2G6IDXNBUWG2BAORUGK6JAMFZGKIDBMNRXK43UN5WWKZBOEBBHK5BAO5UGK3RAMEQGY33OM4QHI4TBNFXCA33GEBQWE5LTMVZSAYLOMQQHK43VOJYGC5DJN5XHGLBAOB2XE43VNFXGOIDJNZ3GC4TJMFRGY6JAORUGKIDTMFWWKICPMJVGKY3UEBSXM2LOMNSXGIDBEBSGK43JM5XCA5DPEBZGKZDVMNSSA5DIMVWSA5LOMRSXEIDBMJZW63DVORSSARDFONYG65DJONWSYIDJOQQGS4ZAORUGK2LSEBZGSZ3IOQWCA2LUEBUXGIDUNBSWS4RAMR2XI6JMEB2G6IDUNBZG65ZAN5TGMIDTOVRWQICHN53GK4TONVSW45BMEBQW4ZBAORXSA4DSN53GSZDFEBXGK5ZAI52WC4TEOMQGM33SEB2GQZLJOIQGM5LUOVZGKIDTMVRXK4TJOR4S4LJNKN2WG2BANBQXGIDCMVSW4IDUNBSSA4DBORUWK3TUEBZXKZTGMVZGC3TDMUQG6ZRAORUGK43FEBBW63DPNZUWK4Z3EBQW4ZBAON2WG2BANFZSA3TPO4QHI2DFEBXGKY3FONZWS5DZEB3WQ2LDNAQGG33OON2HEYLJNZZSA5DIMVWSA5DPEBQWY5DFOIQHI2DFNFZCAZTPOJWWK4RAKN4XG5DFNVZSA33GEBDW65TFOJXG2ZLOOQXCAVDIMUQGQ2LTORXXE6JAN5TCA5DIMUQHA4TFONSW45BAJNUW4ZZAN5TCAR3SMVQXIICCOJUXIYLJNYQGS4ZAMEQGQ2LTORXXE6JAN5TCA4TFOBSWC5DFMQQGS3TKOVZGSZLTEBQW4ZBAOVZXK4TQMF2GS33OOMWCAYLMNQQGQYLWNFXGOIDJNYQGI2LSMVRXIIDPMJVGKY3UEB2GQZJAMVZXIYLCNRUXG2DNMVXHIIDPMYQGC3RAMFRHG33MOV2GKICUPFZGC3TOPEQG65TFOIQHI2DFONSSAU3UMF2GK4ZOEBKG6IDQOJXXMZJAORUGS4ZMEBWGK5BAIZQWG5DTEBRGKIDTOVRG22LUORSWIIDUN4QGCIDDMFXGI2LEEB3W64TMMQXEQZJANBQXGIDSMVTHK43FMQQGQ2LTEBAXG43FNZ2CA5DPEBGGC53TFQQHI2DFEBWW643UEB3WQ33MMVZW63LFEBQW4ZBANZSWGZLTONQXE6JAMZXXEIDUNBSSA4DVMJWGSYZAM5XW6ZBOJBSSA2DBOMQGM33SMJUWIZDFNYQGQ2LTEBDW65TFOJXG64TTEB2G6IDQMFZXGICMMF3XGIDPMYQGS3LNMVSGSYLUMUQGC3TEEBYHEZLTONUW4ZZANFWXA33SORQW4Y3FFQQHK3TMMVZXGIDTOVZXAZLOMRSWIIDJNYQHI2DFNFZCA33QMVZGC5DJN5XCA5DJNRWCA2DJOMQEC43TMVXHIIDTNBXXK3DEEBRGKIDPMJ2GC2LOMVSDWIDBNZSCA53IMVXCA43PEBZXK43QMVXGIZLEFQQGQZJANBQXGIDVOR2GK4TMPEQG4ZLHNRSWG5DFMQQHI3ZAMF2HIZLOMQQHI3ZAORUGK3JOJBSSA2DBOMQHEZLGOVZWKZBAORXSA4DBONZSA33UNBSXEICMMF3XGIDGN5ZCA5DIMUQGCY3DN5WW233EMF2GS33OEBXWMIDMMFZGOZJAMRUXG5DSNFRXI4ZAN5TCA4DFN5YGYZJMEB2W43DFONZSA5DIN5ZWKIDQMVXXA3DFEB3W65LMMQQHEZLMNFXHC5LJONUCA5DIMUQHE2LHNB2CA33GEBJGK4DSMVZWK3TUMF2GS33OEBUW4IDUNBSSATDFM5UXG3DBOR2XEZJMEBQSA4TJM5UHIIDJNZSXG5DJNVQWE3DFEB2G6IDUNBSW2IDBNZSCAZTPOJWWSZDBMJWGKIDUN4QHI6LSMFXHI4ZAN5XGY6JOJBSSA2DBOMQGGYLMNRSWIIDUN5TWK5DIMVZCA3DFM5UXG3DBORUXMZJAMJXWI2LFOMQGC5BAOBWGCY3FOMQHK3TVON2WC3BMEB2W4Y3PNVTG64TUMFRGYZJMEBQW4ZBAMRUXG5DBNZ2CAZTSN5WSA5DIMUQGIZLQN5ZWS5DPOJ4SA33GEB2GQZLJOIQHA5LCNRUWGICSMVRW64TEOMWCAZTPOIQHI2DFEBZW63DFEBYHK4TQN5ZWKIDPMYQGMYLUNFTXK2LOM4QHI2DFNUQGS3TUN4QGG33NOBWGSYLOMNSSA53JORUCA2DJOMQG2ZLBON2XEZLTFZEGKIDIMFZSAZDJONZW63DWMVSCAUTFOBZGK43FNZ2GC5DJOZSSASDPOVZWK4ZAOJSXAZLBORSWI3DZFQQGM33SEBXXA4DPONUW4ZZAO5UXI2BANVQW43DZEBTGS4TNNZSXG4ZANBUXGIDJNZ3GC43JN5XHGIDPNYQHI2DFEBZGSZ3IORZSA33GEB2GQZJAOBSW64DMMUXEQZJANBQXGIDSMVTHK43FMQQGM33SEBQSA3DPNZTSA5DJNVSSYIDBMZ2GK4RAON2WG2BAMRUXG43PNR2XI2LPNZZSYIDUN4QGGYLVONSSA33UNBSXE4ZAORXSAYTFEBSWYZLDORSWIOZAO5UGK4TFMJ4SA5DIMUQEYZLHNFZWYYLUNF3GKIDQN53WK4TTFQQGS3TDMFYGCYTMMUQG6ZRAIFXG42LINFWGC5DJN5XCYIDIMF3GKIDSMV2HK4TOMVSCA5DPEB2GQZJAKBSW64DMMUQGC5BANRQXEZ3FEBTG64RAORUGK2LSEBSXQZLSMNUXGZJ3EB2GQZJAKN2GC5DFEBZGK3LBNFXGS3THEBUW4IDUNBSSA3LFMFXCA5DJNVSSAZLYOBXXGZLEEB2G6IDBNRWCA5DIMUQGIYLOM5SXE4ZAN5TCA2LOOZQXG2LPNYQGM4TPNUQHO2LUNBXXK5BMEBQW4ZBAMNXW45TVNRZWS33OOMQHO2LUNBUW4LSIMUQGQYLTEBSW4ZDFMF3G65LSMVSCA5DPEBYHEZLWMVXHIIDUNBSSA4DPOB2WYYLUNFXW4IDPMYQHI2DFONSSAU3UMF2GK4Z3EBTG64RAORUGC5BAOB2XE4DPONSSA33CON2HE5LDORUW4ZZAORUGKICMMF3XGIDGN5ZCATTBOR2XEYLMNF5GC5DJN5XCA33GEBDG64TFNFTW4ZLSOM5SA4TFMZ2XG2LOM4QHI3ZAOBQXG4ZAN52GQZLSOMQHI3ZAMVXGG33VOJQWOZJAORUGK2LSEBWWSZ3SMF2GS33OOMQGQ2LUNBSXELBAMFXGIIDSMFUXG2LOM4QHI2DFEBRW63TENF2GS33OOMQG6ZRANZSXOICBOBYHE33QOJUWC5DJN5XHGIDPMYQEYYLOMRZS4SDFEBUGC4ZAN5RHG5DSOVRXIZLEEB2GQZJAIFSG22LONFZXI4TBORUW63RAN5TCASTVON2GSY3FFQQGE6JAOJSWM5LTNFXGOIDINFZSAQLTONSW45BAORXSATDBO5ZSAZTPOIQGK43UMFRGY2LTNBUW4ZZAJJ2WI2LDNFQXE6JAOBXXOZLSOMXEQZJANBQXGIDNMFSGKICKOVSGOZLTEBSGK4DFNZSGK3TUEBXW4IDINFZSAV3JNRWCAYLMN5XGKLBAMZXXEIDUNBSSA5DFNZ2XEZJAN5TCA5DIMVUXEIDPMZTGSY3FOMWCAYLOMQQHI2DFEBQW233VNZ2CAYLOMQQHAYLZNVSW45BAN5TCA5DIMVUXEIDTMFWGC4TJMVZS4SDFEBUGC4ZAMVZGKY3UMVSCAYJANV2WY5DJOR2WIZJAN5TCATTFO4QE6ZTGNFRWK4ZMEBQW4ZBAONSW45BANBUXI2DFOIQHG53BOJWXGIDPMYQE6ZTGNFRWK4TTEB2G6IDIMFZHEYLTOMQG65LSEBYGK33QNRSSYIDBNZSCAZLBOQQG65LUEB2GQZLJOIQHG5LCON2GC3TDMUXEQZJANBQXGIDLMVYHIIDBNVXW4ZZAOVZSYIDJNYQHI2LNMVZSA33GEBYGKYLDMUWCAU3UMFXGI2LOM4QEC4TNNFSXGIDXNF2GQ33VOQQHI2DFEBBW63TTMVXHIIDPMYQG65LSEBWGKZ3JONWGC5DVOJSXGLSIMUQGQYLTEBQWMZTFMN2GKZBAORXSA4TFNZSGK4RAORUGKICNNFWGS5DBOJ4SA2LOMRSXAZLOMRSW45BAN5TCAYLOMQQHG5LQMVZGS33SEB2G6IDUNBSSAQ3JOZUWYIDQN53WK4ROJBSSA2DBOMQGG33NMJUW4ZLEEB3WS5DIEBXXI2DFOJZSA5DPEBZXKYTKMVRXIIDVOMQHI3ZAMEQGU5LSNFZWI2LDORUW63RAMZXXEZLJM5XCA5DPEBXXK4RAMNXW443UNF2HK5DJN5XCYIDBNZSCA5LOMFRWW3TPO5WGKZDHMVSCAYTZEBXXK4RANRQXO4Z3EBTWS5TJNZTSA2DJOMQEC43TMVXHIIDUN4QHI2DFNFZCAQLDORZSA33GEBYHEZLUMVXGIZLEEBGGKZ3JONWGC5DJN5XDURTPOIQFC5LBOJ2GK4TJNZTSA3DBOJTWKIDCN5SGSZLTEBXWMIDBOJWWKZBAORZG633QOMQGC3LPNZTSA5LTHJDG64RAOBZG65DFMN2GS3THEB2GQZLNFQQGE6JAMEQG233DNMQFI4TJMFWCYIDGOJXW2IDQOVXGS43INVSW45BAMZXXEIDBNZ4SATLVOJSGK4TTEB3WQ2LDNAQHI2DFPEQHG2DPOVWGIIDDN5WW22LUEBXW4IDUNBSSASLONBQWE2LUMFXHI4ZAN5TCA5DIMVZWKICTORQXIZLTHJDG64RAMN2XI5DJNZTSA33GMYQG65LSEBKHEYLEMUQHO2LUNAQGC3DMEBYGC4TUOMQG6ZRAORUGKIDXN5ZGYZB2IZXXEIDJNVYG643JNZTSAVDBPBSXGIDPNYQHK4ZAO5UXI2DPOV2CA33VOIQEG33OONSW45B2IZXXEIDEMVYHE2LWNFXGOIDVOMQGS3RANVQW46JAMNQXGZLTFQQG6ZRAORUGKIDCMVXGKZTJORZSA33GEBKHE2LBNQQGE6JAJJ2XE6J2IZXXEIDUOJQW443QN5ZHI2LOM4QHK4ZAMJSXS33OMQQFGZLBOMQHI3ZAMJSSA5DSNFSWIIDGN5ZCA4DSMV2GK3TEMVSCA33GMZSW4Y3FONDG64RAMFRG63DJONUGS3THEB2GQZJAMZZGKZJAKN4XG5DFNUQG6ZRAIVXGO3DJONUCATDBO5ZSA2LOEBQSA3TFNFTWQYTPOVZGS3THEBIHE33WNFXGGZJMEBSXG5DBMJWGS43INFXGOIDUNBSXEZLJNYQGC3RAIFZGE2LUOJQXE6JAM5XXMZLSNZWWK3TUFQQGC3TEEBSW43DBOJTWS3THEBUXI4ZAIJXXK3TEMFZGSZLTEBZW6IDBOMQHI3ZAOJSW4ZDFOIQGS5BAMF2CA33OMNSSAYLOEBSXQYLNOBWGKIDBNZSCAZTJOQQGS3TTORZHK3LFNZ2CAZTPOIQGS3TUOJXWI5LDNFXGOIDUNBSSA43BNVSSAYLCONXWY5LUMUQHE5LMMUQGS3TUN4QHI2DFONSSAQ3PNRXW42LFOM5EM33SEB2GC23JNZTSAYLXMF4SA33VOIQEG2DBOJ2GK4TTFQQGCYTPNRUXG2DJNZTSA33VOIQG233TOQQHMYLMOVQWE3DFEBGGC53TFQQGC3TEEBQWY5DFOJUW4ZZAMZ2W4ZDBNVSW45DBNRWHSIDUNBSSARTPOJWXGIDPMYQG65LSEBDW65TFOJXG2ZLOORZTURTPOIQHG5LTOBSW4ZDJNZTSA33VOIQG653OEBGGKZ3JONWGC5DVOJSXGLBAMFXGIIDEMVRWYYLSNFXGOIDUNBSW243FNR3GK4ZANFXHMZLTORSWIIDXNF2GQIDQN53WK4RAORXSA3DFM5UXG3DBORSSAZTPOIQHK4ZANFXCAYLMNQQGGYLTMVZSA53IMF2HG33FOZSXELSIMUQGQYLTEBQWEZDJMNQXIZLEEBDW65TFOJXG2ZLOOQQGQZLSMUWCAYTZEBSGKY3MMFZGS3THEB2XGIDPOV2CA33GEBUGS4ZAKBZG65DFMN2GS33OEBQW4ZBAO5QWO2LOM4QFOYLSEBQWOYLJNZZXIIDVOMXEQZJANBQXGIDQNR2W4ZDFOJSWIIDPOVZCA43FMFZSYIDSMF3GCZ3FMQQG65LSEBBW6YLTORZSYIDCOVZG45BAN52XEIDUN53W44ZMEBQW4ZBAMRSXG5DSN54WKZBAORUGKIDMNF3GK4ZAN5TCA33VOIQHAZLPOBWGKLSIMUQGS4ZAMF2CA5DINFZSA5DJNVSSA5DSMFXHG4DPOJ2GS3THEBWGC4THMUQEC4TNNFSXGIDPMYQGM33SMVUWO3RAJVSXEY3FNZQXE2LFOMQHI3ZAMNXW24DMMVQXIIDUNBSSA53POJVXGIDPMYQGIZLBORUCYIDEMVZW63DBORUW63RAMFXGIIDUPFZGC3TOPEWCAYLMOJSWCZDZEBRGKZ3VNYQHO2LUNAQGG2LSMN2W243UMFXGGZLTEBXWMICDOJ2WK3DUPEQCMIDQMVZGM2LEPEQHGY3BOJRWK3DZEBYGC4TBNRWGK3DFMQQGS3RAORUGKIDNN5ZXIIDCMFZGEYLSN52XGIDBM5SXGLBAMFXGIIDUN52GC3DMPEQHK3TXN5ZHI2DZEB2GQZJAJBSWCZBAN5TCAYJAMNUXM2LMNF5GKZBANZQXI2LPNYXEQZJANBQXGIDDN5XHG5DSMFUW4ZLEEBXXK4RAMZSWY3DPO4QEG2LUNF5GK3TTEB2GC23FNYQEGYLQORUXMZJAN5XCA5DIMUQGQ2LHNAQFGZLBOMQHI3ZAMJSWC4RAIFZG24ZAMFTWC2LOON2CA5DIMVUXEICDN52W45DSPEWCA5DPEBRGKY3PNVSSA5DIMUQGK6DFMN2XI2LPNZSXE4ZAN5TCA5DIMVUXEIDGOJUWK3TEOMQGC3TEEBBHEZLUNBZGK3RMEBXXEIDUN4QGMYLMNQQHI2DFNVZWK3DWMVZSAYTZEB2GQZLJOIQEQYLOMRZS4SDFEBUGC4ZAMV4GG2LUMVSCAZDPNVSXG5DJMMQGS3TTOVZHEZLDORUW63TTEBQW233OM5ZXIIDVOMWCAYLOMQQGQYLTEBSW4ZDFMF3G65LSMVSCA5DPEBRHE2LOM4QG63RAORUGKIDJNZUGCYTJORQW45DTEBXWMIDPOVZCAZTSN5XHI2LFOJZSYIDUNBSSA3LFOJRWS3DFONZSASLOMRUWC3RAKNQXMYLHMVZSYIDXNBXXGZJANNXG653OEBZHK3DFEBXWMIDXMFZGMYLSMUWCA2LTEBQW4IDVNZSGS43UNFXGO5LJONUGKZBAMRSXG5DSOVRXI2LPNYQG6ZRAMFWGYIDBM5SXGLBAONSXQZLTEBQW4ZBAMNXW4ZDJORUW63TTFZEW4IDFOZSXE6JAON2GCZ3FEBXWMIDUNBSXGZJAJ5YHA4TFONZWS33OOMQFOZJANBQXMZJAKBSXI2LUNFXW4ZLEEBTG64RAKJSWI4TFONZSA2LOEB2GQZJANVXXG5BANB2W2YTMMUQHIZLSNVZTUICPOVZCA4TFOBSWC5DFMQQFAZLUNF2GS33OOMQGQYLWMUQGEZLFNYQGC3TTO5SXEZLEEBXW43DZEBRHSIDSMVYGKYLUMVSCA2LONJ2XE6JOEBASAUDSNFXGGZJAO5UG643FEBRWQYLSMFRXIZLSEBUXGIDUNB2XGIDNMFZGWZLEEBRHSIDFOZSXE6JAMFRXIIDXNBUWG2BANVQXSIDEMVTGS3TFEBQSAVDZOJQW45BMEBUXGIDVNZTGS5BAORXSAYTFEB2GQZJAOJ2WYZLSEBXWMIDBEBTHEZLFEBYGK33QNRSS4TTPOIQGQYLWMUQFOZJAMJSWK3RAO5QW45DJNZTSA2LOEBQXI5DFNZ2GS33OOMQHI3ZAN52XEICCOJUXI5DJONUCAYTSMV2GQ4TFNYXCAV3FEBUGC5TFEB3WC4TOMVSCA5DIMVWSAZTSN5WSA5DJNVSSA5DPEB2GS3LFEBXWMIDBOR2GK3LQORZSAYTZEB2GQZLJOIQGYZLHNFZWYYLUOVZGKIDUN4QGK6DUMVXGIIDBNYQHK3TXMFZHEYLOORQWE3DFEBVHK4TJONSGSY3UNFXW4IDPOZSXEIDVOMXCAV3FEBUGC5TFEBZGK3LJNZSGKZBAORUGK3JAN5TCA5DIMUQGG2LSMN2W243UMFXGGZLTEBXWMIDPOVZCAZLNNFTXEYLUNFXW4IDBNZSCA43FOR2GYZLNMVXHIIDIMVZGKLRAK5SSA2DBOZSSAYLQOBSWC3DFMQQHI3ZAORUGK2LSEBXGC5DJOZSSA2TVON2GSY3FEBQW4ZBANVQWO3TBNZUW22LUPEWCAYLOMQQHOZJANBQXMZJAMNXW42TVOJSWIIDUNBSW2IDCPEQHI2DFEB2GSZLTEBXWMIDPOVZCAY3PNVWW63RANNUW4ZDSMVSCA5DPEBSGS43BOZXXOIDUNBSXGZJAOVZXK4TQMF2GS33OOMWCA53INFRWQLBAO5XXK3DEEBUW4ZLWNF2GCYTMPEQGS3TUMVZHE5LQOQQG65LSEBRW63TOMVRXI2LPNZZSAYLOMQQGG33SOJSXG4DPNZSGK3TDMUXCAVDIMV4SA5DPN4QGQYLWMUQGEZLFNYQGIZLBMYQHI3ZAORUGKIDWN5UWGZJAN5TCA2TVON2GSY3FEBQW4ZBAN5TCAY3PNZZWC3THOVUW42LUPEXCAV3FEBWXK43UFQQHI2DFOJSWM33SMUWCAYLDOF2WSZLTMNSSA2LOEB2GQZJANZSWGZLTONUXI6JMEB3WQ2LDNAQGIZLON52W4Y3FOMQG65LSEBJWK4DBOJQXI2LPNYWCAYLOMQQGQ33MMQQHI2DFNUWCAYLTEB3WKIDIN5WGIIDUNBSSA4TFON2CA33GEBWWC3TLNFXGILBAIVXGK3LJMVZSA2LOEBLWC4RMEBUW4ICQMVQWGZJAIZZGSZLOMRZS4V3FFQQHI2DFOJSWM33SMUWCA5DIMUQFEZLQOJSXGZLOORQXI2LWMVZSA33GEB2GQZJAOVXGS5DFMQQFG5DBORSXGIDPMYQEC3LFOJUWGYJMEBUW4ICHMVXGK4TBNQQEG33OM5ZGK43TFQQEC43TMVWWE3DFMQWCAYLQOBSWC3DJNZTSA5DPEB2GQZJAKN2XA4TFNVSSASTVMRTWKIDPMYQHI2DFEB3W64TMMQQGM33SEB2GQZJAOJSWG5DJOR2WIZJAN5TCA33VOIQGS3TUMVXHI2LPNZZSYIDEN4WCA2LOEB2GQZJAJZQW2ZJMEBQW4ZBAMJ4SAQLVORUG64TJOR4SA33GEB2GQZJAM5XW6ZBAKBSW64DMMUQG6ZRAORUGK43FEBBW63DPNZUWK4ZMEBZW63DFNVXGY6JAOB2WE3DJONUCAYLOMQQGIZLDNRQXEZJMEBKGQYLUEB2GQZLTMUQFK3TJORSWIICDN5WG63TJMVZSAYLSMUWCAYLOMQQG6ZRAKJUWO2DUEBXXKZ3IOQQHI3ZAMJSSARTSMVSSAYLOMQQES3TEMVYGK3TEMVXHIICTORQXIZLTHMQHI2DBOQQHI2DFPEQGC4TFEBAWE43PNR3GKZBAMZZG63JAMFWGYICBNRWGKZ3JMFXGGZJAORXSA5DIMUQEE4TJORUXG2BAINZG653OFQQGC3TEEB2GQYLUEBQWY3BAOBXWY2LUNFRWC3BAMNXW43TFMN2GS33OEBRGK5DXMVSW4IDUNBSW2IDBNZSCA5DIMUQFG5DBORSSA33GEBDXEZLBOQQEE4TJORQWS3RMEBUXGIDBNZSCA33VM5UHIIDUN4QGEZJAORXXIYLMNR4SAZDJONZW63DWMVSDWIDBNZSCA5DIMF2CAYLTEBDHEZLFEBQW4ZBAJFXGIZLQMVXGIZLOOQQFG5DBORSXGLBAORUGK6JANBQXMZJAMZ2WY3BAKBXXOZLSEB2G6IDMMV3HSICXMFZCYIDDN5XGG3DVMRSSAUDFMFRWKLBAMNXW45DSMFRXIICBNRWGSYLOMNSXGLBAMVZXIYLCNRUXG2BAINXW23LFOJRWKLBAMFXGIIDUN4QGI3ZAMFWGYIDPORUGK4RAIFRXI4ZAMFXGIICUNBUW4Z3TEB3WQ2LDNAQES3TEMVYGK3TEMVXHIICTORQXIZLTEBWWC6JAN5TCA4TJM5UHIIDEN4XCAQLOMQQGM33SEB2GQZJAON2XA4DPOJ2CA33GEB2GQ2LTEBCGKY3MMFZGC5DJN5XCYIDXNF2GQIDBEBTGS4TNEBZGK3DJMFXGGZJAN5XCA5DIMUQHA4TPORSWG5DJN5XCA33GEBSGS5TJNZSSAUDSN53GSZDFNZRWKLBAO5SSA3LVOR2WC3DMPEQHA3DFMRTWKIDUN4QGKYLDNAQG65DIMVZCA33VOIQEY2LWMVZSYIDPOVZCARTPOJ2HK3TFOMQGC3TEEBXXK4RAONQWG4TFMQQEQ33ON5ZC4===";

            byte[] bytes = encoding.GetBytes(source);
            string actual1 = bytes.EncodeToStringByBase32();

            string actual2 = source.EncodeToStringByBase32();

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);

            CollectionAssert.AreEqual(bytes, expected.DecodeToBytesByBase32());
            Assert.AreEqual(source, expected.DecodeToStringByBase32());
        }

        [TestMethod]
        public void Empty_Should()
        {
            Encoding encoding = Encoding.UTF8;

            string source = string.Empty;
            string expected = "";

            byte[] bytes = encoding.GetBytes(source);
            string actual1 = bytes.EncodeToStringByBase32();

            string actual2 = source.EncodeToStringByBase32();

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);

            CollectionAssert.AreEqual(bytes, expected.DecodeToBytesByBase32());
            Assert.AreEqual(source, expected.DecodeToStringByBase32());
        }
    }
}
