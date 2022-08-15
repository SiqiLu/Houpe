// ***********************************************************************
// Solution         : HoupeSolution
// Project          : Houpe.Foundation.Tests
// File             : Base64Extensions_Should.cs
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
    public class Base64Extensions_Should
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

            string expected = "SGVsbG8gV29ybGQh";

            byte[] bytes = encoding.GetBytes(source);
            string actual1 = bytes.EncodeToStringByBase64();

            string actual2 = source.EncodeToStringByBase64();

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);

            CollectionAssert.AreEqual(bytes, expected.DecodeToBytesByBase64());
            Assert.AreEqual(source, expected.DecodeToStringByBase64());
        }

        [TestMethod]
        public void Text_Should()
        {
            Encoding encoding = Encoding.UTF8;

            string source = Data.Replace("\r", "").Replace("\n", "");
            string expected =
                "VGhlIHVuYW5pbW91cyBEZWNsYXJhdGlvbiBvZiB0aGUgdGhpcnRlZW4gdW5pdGVkIFN0YXRlcyBvZiBBbWVyaWNhLCBXaGVuIGluIHRoZSBDb3Vyc2Ugb2YgaHVtYW4gZXZlbnRzLCBpdCBiZWNvbWVzIG5lY2Vzc2FyeSBmb3Igb25lIHBlb3BsZSB0byBkaXNzb2x2ZSB0aGUgcG9saXRpY2FsIGJhbmRzIHdoaWNoIGhhdmUgY29ubmVjdGVkIHRoZW0gd2l0aCBhbm90aGVyLCBhbmQgdG8gYXNzdW1lIGFtb25nIHRoZSBwb3dlcnMgb2YgdGhlIGVhcnRoLCB0aGUgc2VwYXJhdGUgYW5kIGVxdWFsIHN0YXRpb24gdG8gd2hpY2ggdGhlIExhd3Mgb2YgTmF0dXJlIGFuZCBvZiBOYXR1cmUncyBHb2QgZW50aXRsZSB0aGVtLCBhIGRlY2VudCByZXNwZWN0IHRvIHRoZSBvcGluaW9ucyBvZiBtYW5raW5kIHJlcXVpcmVzIHRoYXQgdGhleSBzaG91bGQgZGVjbGFyZSB0aGUgY2F1c2VzIHdoaWNoIGltcGVsIHRoZW0gdG8gdGhlIHNlcGFyYXRpb24uV2UgaG9sZCB0aGVzZSB0cnV0aHMgdG8gYmUgc2VsZi1ldmlkZW50LCB0aGF0IGFsbCBtZW4gYXJlIGNyZWF0ZWQgZXF1YWwsIHRoYXQgdGhleSBhcmUgZW5kb3dlZCBieSB0aGVpciBDcmVhdG9yIHdpdGggY2VydGFpbiB1bmFsaWVuYWJsZSBSaWdodHMsIHRoYXQgYW1vbmcgdGhlc2UgYXJlIExpZmUsIExpYmVydHkgYW5kIHRoZSBwdXJzdWl0IG9mIEhhcHBpbmVzcy4tLVRoYXQgdG8gc2VjdXJlIHRoZXNlIHJpZ2h0cywgR292ZXJubWVudHMgYXJlIGluc3RpdHV0ZWQgYW1vbmcgTWVuLCBkZXJpdmluZyB0aGVpciBqdXN0IHBvd2VycyBmcm9tIHRoZSBjb25zZW50IG9mIHRoZSBnb3Zlcm5lZCwgLS1UaGF0IHdoZW5ldmVyIGFueSBGb3JtIG9mIEdvdmVybm1lbnQgYmVjb21lcyBkZXN0cnVjdGl2ZSBvZiB0aGVzZSBlbmRzLCBpdCBpcyB0aGUgUmlnaHQgb2YgdGhlIFBlb3BsZSB0byBhbHRlciBvciB0byBhYm9saXNoIGl0LCBhbmQgdG8gaW5zdGl0dXRlIG5ldyBHb3Zlcm5tZW50LCBsYXlpbmcgaXRzIGZvdW5kYXRpb24gb24gc3VjaCBwcmluY2lwbGVzIGFuZCBvcmdhbml6aW5nIGl0cyBwb3dlcnMgaW4gc3VjaCBmb3JtLCBhcyB0byB0aGVtIHNoYWxsIHNlZW0gbW9zdCBsaWtlbHkgdG8gZWZmZWN0IHRoZWlyIFNhZmV0eSBhbmQgSGFwcGluZXNzLiBQcnVkZW5jZSwgaW5kZWVkLCB3aWxsIGRpY3RhdGUgdGhhdCBHb3Zlcm5tZW50cyBsb25nIGVzdGFibGlzaGVkIHNob3VsZCBub3QgYmUgY2hhbmdlZCBmb3IgbGlnaHQgYW5kIHRyYW5zaWVudCBjYXVzZXM7IGFuZCBhY2NvcmRpbmdseSBhbGwgZXhwZXJpZW5jZSBoYXRoIHNoZXduLCB0aGF0IG1hbmtpbmQgYXJlIG1vcmUgZGlzcG9zZWQgdG8gc3VmZmVyLCB3aGlsZSBldmlscyBhcmUgc3VmZmVyYWJsZSwgdGhhbiB0byByaWdodCB0aGVtc2VsdmVzIGJ5IGFib2xpc2hpbmcgdGhlIGZvcm1zIHRvIHdoaWNoIHRoZXkgYXJlIGFjY3VzdG9tZWQuIEJ1dCB3aGVuIGEgbG9uZyB0cmFpbiBvZiBhYnVzZXMgYW5kIHVzdXJwYXRpb25zLCBwdXJzdWluZyBpbnZhcmlhYmx5IHRoZSBzYW1lIE9iamVjdCBldmluY2VzIGEgZGVzaWduIHRvIHJlZHVjZSB0aGVtIHVuZGVyIGFic29sdXRlIERlc3BvdGlzbSwgaXQgaXMgdGhlaXIgcmlnaHQsIGl0IGlzIHRoZWlyIGR1dHksIHRvIHRocm93IG9mZiBzdWNoIEdvdmVybm1lbnQsIGFuZCB0byBwcm92aWRlIG5ldyBHdWFyZHMgZm9yIHRoZWlyIGZ1dHVyZSBzZWN1cml0eS4tLVN1Y2ggaGFzIGJlZW4gdGhlIHBhdGllbnQgc3VmZmVyYW5jZSBvZiB0aGVzZSBDb2xvbmllczsgYW5kIHN1Y2ggaXMgbm93IHRoZSBuZWNlc3NpdHkgd2hpY2ggY29uc3RyYWlucyB0aGVtIHRvIGFsdGVyIHRoZWlyIGZvcm1lciBTeXN0ZW1zIG9mIEdvdmVybm1lbnQuIFRoZSBoaXN0b3J5IG9mIHRoZSBwcmVzZW50IEtpbmcgb2YgR3JlYXQgQnJpdGFpbiBpcyBhIGhpc3Rvcnkgb2YgcmVwZWF0ZWQgaW5qdXJpZXMgYW5kIHVzdXJwYXRpb25zLCBhbGwgaGF2aW5nIGluIGRpcmVjdCBvYmplY3QgdGhlIGVzdGFibGlzaG1lbnQgb2YgYW4gYWJzb2x1dGUgVHlyYW5ueSBvdmVyIHRoZXNlIFN0YXRlcy4gVG8gcHJvdmUgdGhpcywgbGV0IEZhY3RzIGJlIHN1Ym1pdHRlZCB0byBhIGNhbmRpZCB3b3JsZC5IZSBoYXMgcmVmdXNlZCBoaXMgQXNzZW50IHRvIExhd3MsIHRoZSBtb3N0IHdob2xlc29tZSBhbmQgbmVjZXNzYXJ5IGZvciB0aGUgcHVibGljIGdvb2QuSGUgaGFzIGZvcmJpZGRlbiBoaXMgR292ZXJub3JzIHRvIHBhc3MgTGF3cyBvZiBpbW1lZGlhdGUgYW5kIHByZXNzaW5nIGltcG9ydGFuY2UsIHVubGVzcyBzdXNwZW5kZWQgaW4gdGhlaXIgb3BlcmF0aW9uIHRpbGwgaGlzIEFzc2VudCBzaG91bGQgYmUgb2J0YWluZWQ7IGFuZCB3aGVuIHNvIHN1c3BlbmRlZCwgaGUgaGFzIHV0dGVybHkgbmVnbGVjdGVkIHRvIGF0dGVuZCB0byB0aGVtLkhlIGhhcyByZWZ1c2VkIHRvIHBhc3Mgb3RoZXIgTGF3cyBmb3IgdGhlIGFjY29tbW9kYXRpb24gb2YgbGFyZ2UgZGlzdHJpY3RzIG9mIHBlb3BsZSwgdW5sZXNzIHRob3NlIHBlb3BsZSB3b3VsZCByZWxpbnF1aXNoIHRoZSByaWdodCBvZiBSZXByZXNlbnRhdGlvbiBpbiB0aGUgTGVnaXNsYXR1cmUsIGEgcmlnaHQgaW5lc3RpbWFibGUgdG8gdGhlbSBhbmQgZm9ybWlkYWJsZSB0byB0eXJhbnRzIG9ubHkuSGUgaGFzIGNhbGxlZCB0b2dldGhlciBsZWdpc2xhdGl2ZSBib2RpZXMgYXQgcGxhY2VzIHVudXN1YWwsIHVuY29tZm9ydGFibGUsIGFuZCBkaXN0YW50IGZyb20gdGhlIGRlcG9zaXRvcnkgb2YgdGhlaXIgcHVibGljIFJlY29yZHMsIGZvciB0aGUgc29sZSBwdXJwb3NlIG9mIGZhdGlndWluZyB0aGVtIGludG8gY29tcGxpYW5jZSB3aXRoIGhpcyBtZWFzdXJlcy5IZSBoYXMgZGlzc29sdmVkIFJlcHJlc2VudGF0aXZlIEhvdXNlcyByZXBlYXRlZGx5LCBmb3Igb3Bwb3Npbmcgd2l0aCBtYW5seSBmaXJtbmVzcyBoaXMgaW52YXNpb25zIG9uIHRoZSByaWdodHMgb2YgdGhlIHBlb3BsZS5IZSBoYXMgcmVmdXNlZCBmb3IgYSBsb25nIHRpbWUsIGFmdGVyIHN1Y2ggZGlzc29sdXRpb25zLCB0byBjYXVzZSBvdGhlcnMgdG8gYmUgZWxlY3RlZDsgd2hlcmVieSB0aGUgTGVnaXNsYXRpdmUgcG93ZXJzLCBpbmNhcGFibGUgb2YgQW5uaWhpbGF0aW9uLCBoYXZlIHJldHVybmVkIHRvIHRoZSBQZW9wbGUgYXQgbGFyZ2UgZm9yIHRoZWlyIGV4ZXJjaXNlOyB0aGUgU3RhdGUgcmVtYWluaW5nIGluIHRoZSBtZWFuIHRpbWUgZXhwb3NlZCB0byBhbGwgdGhlIGRhbmdlcnMgb2YgaW52YXNpb24gZnJvbSB3aXRob3V0LCBhbmQgY29udnVsc2lvbnMgd2l0aGluLkhlIGhhcyBlbmRlYXZvdXJlZCB0byBwcmV2ZW50IHRoZSBwb3B1bGF0aW9uIG9mIHRoZXNlIFN0YXRlczsgZm9yIHRoYXQgcHVycG9zZSBvYnN0cnVjdGluZyB0aGUgTGF3cyBmb3IgTmF0dXJhbGl6YXRpb24gb2YgRm9yZWlnbmVyczsgcmVmdXNpbmcgdG8gcGFzcyBvdGhlcnMgdG8gZW5jb3VyYWdlIHRoZWlyIG1pZ3JhdGlvbnMgaGl0aGVyLCBhbmQgcmFpc2luZyB0aGUgY29uZGl0aW9ucyBvZiBuZXcgQXBwcm9wcmlhdGlvbnMgb2YgTGFuZHMuSGUgaGFzIG9ic3RydWN0ZWQgdGhlIEFkbWluaXN0cmF0aW9uIG9mIEp1c3RpY2UsIGJ5IHJlZnVzaW5nIGhpcyBBc3NlbnQgdG8gTGF3cyBmb3IgZXN0YWJsaXNoaW5nIEp1ZGljaWFyeSBwb3dlcnMuSGUgaGFzIG1hZGUgSnVkZ2VzIGRlcGVuZGVudCBvbiBoaXMgV2lsbCBhbG9uZSwgZm9yIHRoZSB0ZW51cmUgb2YgdGhlaXIgb2ZmaWNlcywgYW5kIHRoZSBhbW91bnQgYW5kIHBheW1lbnQgb2YgdGhlaXIgc2FsYXJpZXMuSGUgaGFzIGVyZWN0ZWQgYSBtdWx0aXR1ZGUgb2YgTmV3IE9mZmljZXMsIGFuZCBzZW50IGhpdGhlciBzd2FybXMgb2YgT2ZmaWNlcnMgdG8gaGFycmFzcyBvdXIgcGVvcGxlLCBhbmQgZWF0IG91dCB0aGVpciBzdWJzdGFuY2UuSGUgaGFzIGtlcHQgYW1vbmcgdXMsIGluIHRpbWVzIG9mIHBlYWNlLCBTdGFuZGluZyBBcm1pZXMgd2l0aG91dCB0aGUgQ29uc2VudCBvZiBvdXIgbGVnaXNsYXR1cmVzLkhlIGhhcyBhZmZlY3RlZCB0byByZW5kZXIgdGhlIE1pbGl0YXJ5IGluZGVwZW5kZW50IG9mIGFuZCBzdXBlcmlvciB0byB0aGUgQ2l2aWwgcG93ZXIuSGUgaGFzIGNvbWJpbmVkIHdpdGggb3RoZXJzIHRvIHN1YmplY3QgdXMgdG8gYSBqdXJpc2RpY3Rpb24gZm9yZWlnbiB0byBvdXIgY29uc3RpdHV0aW9uLCBhbmQgdW5hY2tub3dsZWRnZWQgYnkgb3VyIGxhd3M7IGdpdmluZyBoaXMgQXNzZW50IHRvIHRoZWlyIEFjdHMgb2YgcHJldGVuZGVkIExlZ2lzbGF0aW9uOkZvciBRdWFydGVyaW5nIGxhcmdlIGJvZGllcyBvZiBhcm1lZCB0cm9vcHMgYW1vbmcgdXM6Rm9yIHByb3RlY3RpbmcgdGhlbSwgYnkgYSBtb2NrIFRyaWFsLCBmcm9tIHB1bmlzaG1lbnQgZm9yIGFueSBNdXJkZXJzIHdoaWNoIHRoZXkgc2hvdWxkIGNvbW1pdCBvbiB0aGUgSW5oYWJpdGFudHMgb2YgdGhlc2UgU3RhdGVzOkZvciBjdXR0aW5nIG9mZiBvdXIgVHJhZGUgd2l0aCBhbGwgcGFydHMgb2YgdGhlIHdvcmxkOkZvciBpbXBvc2luZyBUYXhlcyBvbiB1cyB3aXRob3V0IG91ciBDb25zZW50OkZvciBkZXByaXZpbmcgdXMgaW4gbWFueSBjYXNlcywgb2YgdGhlIGJlbmVmaXRzIG9mIFRyaWFsIGJ5IEp1cnk6Rm9yIHRyYW5zcG9ydGluZyB1cyBiZXlvbmQgU2VhcyB0byBiZSB0cmllZCBmb3IgcHJldGVuZGVkIG9mZmVuY2VzRm9yIGFib2xpc2hpbmcgdGhlIGZyZWUgU3lzdGVtIG9mIEVuZ2xpc2ggTGF3cyBpbiBhIG5laWdoYm91cmluZyBQcm92aW5jZSwgZXN0YWJsaXNoaW5nIHRoZXJlaW4gYW4gQXJiaXRyYXJ5IGdvdmVybm1lbnQsIGFuZCBlbmxhcmdpbmcgaXRzIEJvdW5kYXJpZXMgc28gYXMgdG8gcmVuZGVyIGl0IGF0IG9uY2UgYW4gZXhhbXBsZSBhbmQgZml0IGluc3RydW1lbnQgZm9yIGludHJvZHVjaW5nIHRoZSBzYW1lIGFic29sdXRlIHJ1bGUgaW50byB0aGVzZSBDb2xvbmllczpGb3IgdGFraW5nIGF3YXkgb3VyIENoYXJ0ZXJzLCBhYm9saXNoaW5nIG91ciBtb3N0IHZhbHVhYmxlIExhd3MsIGFuZCBhbHRlcmluZyBmdW5kYW1lbnRhbGx5IHRoZSBGb3JtcyBvZiBvdXIgR292ZXJubWVudHM6Rm9yIHN1c3BlbmRpbmcgb3VyIG93biBMZWdpc2xhdHVyZXMsIGFuZCBkZWNsYXJpbmcgdGhlbXNlbHZlcyBpbnZlc3RlZCB3aXRoIHBvd2VyIHRvIGxlZ2lzbGF0ZSBmb3IgdXMgaW4gYWxsIGNhc2VzIHdoYXRzb2V2ZXIuSGUgaGFzIGFiZGljYXRlZCBHb3Zlcm5tZW50IGhlcmUsIGJ5IGRlY2xhcmluZyB1cyBvdXQgb2YgaGlzIFByb3RlY3Rpb24gYW5kIHdhZ2luZyBXYXIgYWdhaW5zdCB1cy5IZSBoYXMgcGx1bmRlcmVkIG91ciBzZWFzLCByYXZhZ2VkIG91ciBDb2FzdHMsIGJ1cm50IG91ciB0b3ducywgYW5kIGRlc3Ryb3llZCB0aGUgbGl2ZXMgb2Ygb3VyIHBlb3BsZS5IZSBpcyBhdCB0aGlzIHRpbWUgdHJhbnNwb3J0aW5nIGxhcmdlIEFybWllcyBvZiBmb3JlaWduIE1lcmNlbmFyaWVzIHRvIGNvbXBsZWF0IHRoZSB3b3JrcyBvZiBkZWF0aCwgZGVzb2xhdGlvbiBhbmQgdHlyYW5ueSwgYWxyZWFkeSBiZWd1biB3aXRoIGNpcmN1bXN0YW5jZXMgb2YgQ3J1ZWx0eSAmIHBlcmZpZHkgc2NhcmNlbHkgcGFyYWxsZWxlZCBpbiB0aGUgbW9zdCBiYXJiYXJvdXMgYWdlcywgYW5kIHRvdGFsbHkgdW53b3J0aHkgdGhlIEhlYWQgb2YgYSBjaXZpbGl6ZWQgbmF0aW9uLkhlIGhhcyBjb25zdHJhaW5lZCBvdXIgZmVsbG93IENpdGl6ZW5zIHRha2VuIENhcHRpdmUgb24gdGhlIGhpZ2ggU2VhcyB0byBiZWFyIEFybXMgYWdhaW5zdCB0aGVpciBDb3VudHJ5LCB0byBiZWNvbWUgdGhlIGV4ZWN1dGlvbmVycyBvZiB0aGVpciBmcmllbmRzIGFuZCBCcmV0aHJlbiwgb3IgdG8gZmFsbCB0aGVtc2VsdmVzIGJ5IHRoZWlyIEhhbmRzLkhlIGhhcyBleGNpdGVkIGRvbWVzdGljIGluc3VycmVjdGlvbnMgYW1vbmdzdCB1cywgYW5kIGhhcyBlbmRlYXZvdXJlZCB0byBicmluZyBvbiB0aGUgaW5oYWJpdGFudHMgb2Ygb3VyIGZyb250aWVycywgdGhlIG1lcmNpbGVzcyBJbmRpYW4gU2F2YWdlcywgd2hvc2Uga25vd24gcnVsZSBvZiB3YXJmYXJlLCBpcyBhbiB1bmRpc3Rpbmd1aXNoZWQgZGVzdHJ1Y3Rpb24gb2YgYWxsIGFnZXMsIHNleGVzIGFuZCBjb25kaXRpb25zLkluIGV2ZXJ5IHN0YWdlIG9mIHRoZXNlIE9wcHJlc3Npb25zIFdlIGhhdmUgUGV0aXRpb25lZCBmb3IgUmVkcmVzcyBpbiB0aGUgbW9zdCBodW1ibGUgdGVybXM6IE91ciByZXBlYXRlZCBQZXRpdGlvbnMgaGF2ZSBiZWVuIGFuc3dlcmVkIG9ubHkgYnkgcmVwZWF0ZWQgaW5qdXJ5LiBBIFByaW5jZSB3aG9zZSBjaGFyYWN0ZXIgaXMgdGh1cyBtYXJrZWQgYnkgZXZlcnkgYWN0IHdoaWNoIG1heSBkZWZpbmUgYSBUeXJhbnQsIGlzIHVuZml0IHRvIGJlIHRoZSBydWxlciBvZiBhIGZyZWUgcGVvcGxlLk5vciBoYXZlIFdlIGJlZW4gd2FudGluZyBpbiBhdHRlbnRpb25zIHRvIG91ciBCcml0dGlzaCBicmV0aHJlbi4gV2UgaGF2ZSB3YXJuZWQgdGhlbSBmcm9tIHRpbWUgdG8gdGltZSBvZiBhdHRlbXB0cyBieSB0aGVpciBsZWdpc2xhdHVyZSB0byBleHRlbmQgYW4gdW53YXJyYW50YWJsZSBqdXJpc2RpY3Rpb24gb3ZlciB1cy4gV2UgaGF2ZSByZW1pbmRlZCB0aGVtIG9mIHRoZSBjaXJjdW1zdGFuY2VzIG9mIG91ciBlbWlncmF0aW9uIGFuZCBzZXR0bGVtZW50IGhlcmUuIFdlIGhhdmUgYXBwZWFsZWQgdG8gdGhlaXIgbmF0aXZlIGp1c3RpY2UgYW5kIG1hZ25hbmltaXR5LCBhbmQgd2UgaGF2ZSBjb25qdXJlZCB0aGVtIGJ5IHRoZSB0aWVzIG9mIG91ciBjb21tb24ga2luZHJlZCB0byBkaXNhdm93IHRoZXNlIHVzdXJwYXRpb25zLCB3aGljaCwgd291bGQgaW5ldml0YWJseSBpbnRlcnJ1cHQgb3VyIGNvbm5lY3Rpb25zIGFuZCBjb3JyZXNwb25kZW5jZS4gVGhleSB0b28gaGF2ZSBiZWVuIGRlYWYgdG8gdGhlIHZvaWNlIG9mIGp1c3RpY2UgYW5kIG9mIGNvbnNhbmd1aW5pdHkuIFdlIG11c3QsIHRoZXJlZm9yZSwgYWNxdWllc2NlIGluIHRoZSBuZWNlc3NpdHksIHdoaWNoIGRlbm91bmNlcyBvdXIgU2VwYXJhdGlvbiwgYW5kIGhvbGQgdGhlbSwgYXMgd2UgaG9sZCB0aGUgcmVzdCBvZiBtYW5raW5kLCBFbmVtaWVzIGluIFdhciwgaW4gUGVhY2UgRnJpZW5kcy5XZSwgdGhlcmVmb3JlLCB0aGUgUmVwcmVzZW50YXRpdmVzIG9mIHRoZSB1bml0ZWQgU3RhdGVzIG9mIEFtZXJpY2EsIGluIEdlbmVyYWwgQ29uZ3Jlc3MsIEFzc2VtYmxlZCwgYXBwZWFsaW5nIHRvIHRoZSBTdXByZW1lIEp1ZGdlIG9mIHRoZSB3b3JsZCBmb3IgdGhlIHJlY3RpdHVkZSBvZiBvdXIgaW50ZW50aW9ucywgZG8sIGluIHRoZSBOYW1lLCBhbmQgYnkgQXV0aG9yaXR5IG9mIHRoZSBnb29kIFBlb3BsZSBvZiB0aGVzZSBDb2xvbmllcywgc29sZW1ubHkgcHVibGlzaCBhbmQgZGVjbGFyZSwgVGhhdCB0aGVzZSBVbml0ZWQgQ29sb25pZXMgYXJlLCBhbmQgb2YgUmlnaHQgb3VnaHQgdG8gYmUgRnJlZSBhbmQgSW5kZXBlbmRlbnQgU3RhdGVzOyB0aGF0IHRoZXkgYXJlIEFic29sdmVkIGZyb20gYWxsIEFsbGVnaWFuY2UgdG8gdGhlIEJyaXRpc2ggQ3Jvd24sIGFuZCB0aGF0IGFsbCBwb2xpdGljYWwgY29ubmVjdGlvbiBiZXR3ZWVuIHRoZW0gYW5kIHRoZSBTdGF0ZSBvZiBHcmVhdCBCcml0YWluLCBpcyBhbmQgb3VnaHQgdG8gYmUgdG90YWxseSBkaXNzb2x2ZWQ7IGFuZCB0aGF0IGFzIEZyZWUgYW5kIEluZGVwZW5kZW50IFN0YXRlcywgdGhleSBoYXZlIGZ1bGwgUG93ZXIgdG8gbGV2eSBXYXIsIGNvbmNsdWRlIFBlYWNlLCBjb250cmFjdCBBbGxpYW5jZXMsIGVzdGFibGlzaCBDb21tZXJjZSwgYW5kIHRvIGRvIGFsbCBvdGhlciBBY3RzIGFuZCBUaGluZ3Mgd2hpY2ggSW5kZXBlbmRlbnQgU3RhdGVzIG1heSBvZiByaWdodCBkby4gQW5kIGZvciB0aGUgc3VwcG9ydCBvZiB0aGlzIERlY2xhcmF0aW9uLCB3aXRoIGEgZmlybSByZWxpYW5jZSBvbiB0aGUgcHJvdGVjdGlvbiBvZiBkaXZpbmUgUHJvdmlkZW5jZSwgd2UgbXV0dWFsbHkgcGxlZGdlIHRvIGVhY2ggb3RoZXIgb3VyIExpdmVzLCBvdXIgRm9ydHVuZXMgYW5kIG91ciBzYWNyZWQgSG9ub3Iu";

            byte[] bytes = encoding.GetBytes(source);
            string actual1 = bytes.EncodeToStringByBase64();

            string actual2 = source.EncodeToStringByBase64();

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);

            CollectionAssert.AreEqual(bytes, expected.DecodeToBytesByBase64());
            Assert.AreEqual(source, expected.DecodeToStringByBase64());
        }

        [TestMethod]
        public void Empty_Should()
        {
            Encoding encoding = Encoding.UTF8;

            string source = string.Empty;
            string expected = "";

            byte[] bytes = encoding.GetBytes(source);
            string actual1 = bytes.EncodeToStringByBase64();

            string actual2 = source.EncodeToStringByBase64();

            Assert.AreEqual(expected, actual1);
            Assert.AreEqual(expected, actual2);

            CollectionAssert.AreEqual(bytes, expected.DecodeToBytesByBase64());
            Assert.AreEqual(source, expected.DecodeToStringByBase64());
        }
    }
}
