using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaS2.Fighting.Tournament
{
    public class TournamentInfo
    {
        public int Level { get; set; }
        public int DuelsCount { get; set; }
        public int ArenaId { get; set; }
        public string Name { get; set; }
        public string VillainName { get; set; }
        public string Description { get; set; }
        public Boss Boss { get; set; }
    }
}
/*
 * with(tournament_table)
{
   arena_names = new Array("","Dungeon","Provincial Arena","The Ampitheatre","Grand Arena","Imperial Collesseum","Emperor\'s Palace")
   tournament1 = new Array(4,4,2,"Woolridge\'s Meat Emporium Cup","John \'The Butcher\' Woolridge is a pillar of the community. Every year he hosts a tournament for low level gladiators to gain valuable experience. The winner even gets to take on Woolridge himself for a shot at big prizemoney.")
   tournament2 = new Array(7,5,2,"Midsummer Blades","The Midsummer Festival is held at the height of summer and attracts travellers from all across the realms of Brandor. One of the Festival\'s highlights is the Midsummer Blades, a tournament for up and coming gladiators such as yourself.")
   tournament3 = new Array(9,6,2,"Shardstrike Memorial","Bors Shardstrike was a great general who died fighting at the Defence of Phaetor in 1044. This tournament is held in his honour and many brave soldiers compete to hold the title of Shardstriker.")
   tournament4 = new Array(12,7,3,"Silver Circle Invitational","The deeply pious Knights of the Silver Circle are one of the best fighting forces in all Brandor. Mostly made up of crusading lords, the order is secretive and uses the tournament to fish for possible new recruits.")
   tournament5 = new Array(15,8,3,"Great Beast\'s Cup","The Great Beaat is spoken about in hushed whispers throughout this part of Brandor, and with good reason. He has never been defeated in combat. Each year he invites the bravest warriors to fight for the honour of facing him in single combat.")
   tournament6 = new Array(18,9,3,"Penitent King\'s Robe","As legend has it, the Penitent King ruled as a tyrant over the land for much of his life until a kitchen serf saved him from drowning. He saw the error of his ways, and gave the peasant his royal robe, which has since become a much sought after treasure for gladiators to compete over.")
   tournament7 = new Array(21,10,1,"Dungeon Hack","Since many gladiators were once prisoners, it seems fitting that a tournament is held in the emperor\'s dungeon every so often. It is the highlight of the year for the dungeon\'s inmates, most of whom don\'t get out very much at all.")
   tournament8 = new Array(24,11,3,"Pillars of Spheracles","Spheracles, once beloved of the gods, was punished to forever move giant stones with a pillar with only one week of rest a year. In that week, his avatar travels to the Arena to host a tournament held in his honour.")
   tournament9 = new Array(27,12,4,"Master\'s Court","The Master\'s Court is the first tournament to be held in the old Grand Arena, the second largest stadium in the realm. Many great gladiators have fought and died competing for this most prestigious of titles.")
   tournament10 = new Array(30,13,4,"Gaiax\' Eye","The monstrous cyclopes Gaiax boasts that the first man to defeat him in combat will have his eye as a prize. The eye is rumoured to be worth a small fortune in gold.")
   tournament11 = new Array(33,14,4,"Mighty Sandal","Sandals, being both comfortable and practical, are much favoured by the citizens of the realm. So much so that this tournament for veteran gladiators has even been named after the humble sandal, the realm\'s favourite footwear apparel.")
   tournament12 = new Array(36,15,5,"Imperial Open","Gladiators who rise to such lofty heights as yours are invited to fight in the mighty Imperial Collesseum for the first time. The breathtaking collesseum is the largest arena in the realm, and only the most skilled warriors may grace its sands.")
   tournament13 = new Array(39,16,1,"Archfiend\'s Furnace","A vile demonic presence is trapped the Emperor\'s dungeons but breaks free each year to plague the realm. Only the bravest gladiators may venture deep into the dungeons to enslave him once again.")
   tournament14 = new Array(42,17,5,"Duel of Heroes","The Duel is the ultimate celebrity tournament in the realm. Famous warriors and legendary fighters, past and present, dazzle the crowd with some of the greatest one on one combat ever seen.")
   tournament15 = new Array(44,18,5,"Orb of Bargle","The evil sorcerer Bargle has long terrorised the realm with his malevelont wizardry. He hosts a tournament here for his own inscrutable purposes. You have been invited to compete.")
   tournament16 = new Array(46,19,5,"Archangel\'s Mantle","The gods keep a keen eye on the tournament and send down an archangel each year to challenge the most worthy gladiators. The archangels, avatars of the gods themselves, will challenge even the best gladiators right to the very core.")
   tournament17 = new Array(48,20,6,"Emperor\'s Invitational","Winners of the Archangel\'s Mantle are invited to the Imperial Palace to fight in a series of tournaments overseen by the Emperor. Win your way to the top of the ladder here and confront your ultimate self.")
   tournament18 = new Array(50,20,6,"Emperor\'s Throne","Those twenty great champions who defeat their own demons now face off in this, the ultimate tournament. Arena champions and heroes of legend will meet the Emperor in single combat. All roads have led to this, your greatest test.")
   tournament19 = new Array(50,20,6,"Emperor\'s Throne II","Those twenty great champions who defeat their own demons now face off in this, the ultimate tournament. Arena champions and heroes of legend will meet the Emperor in single combat. All roads have led to this, your greatest test.")
   tournament20 = new Array(50,20,6,"Emperor\'s Throne III","Those twenty great champions who defeat their own demons now face off in this, the ultimate tournament. Arena champions and heroes of legend will meet the Emperor in single combat. All roads have led to this, your greatest test.")
   
};
 * */
