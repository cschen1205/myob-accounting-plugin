﻿<%@ Page Language="C#" MasterPageFile="~/OAS.Master" AutoEventWireup="true" CodeBehind="ch03_01.aspx.cs" Inherits="OAS.practice.ch03_01" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#switcher {
  float: right;
  background-color: #ddd;
  border: 1px solid #000;
  margin: 10px;
  padding: 10px;
  font-size: .9em;
}
#switcher h3 {
  margin: 0;
}
#switcher .button {
  width: 100px;
  float: left;
  text-align: center;
  margin: 10px;
  padding: 10px;
  background-color: #fff;
  border-top: 3px solid #888;
  border-left: 3px solid #888;
  border-bottom: 3px solid #444;
  border-right: 3px solid #444;
}
#header {
  clear: both;
}
.selected 
{
	font-weight: bold;
}
.mouseover
{
	background-color: #00ff00;
}
.mouseout
{
	 background-color: #fff;
}
body.large .chapter {
  font-size: 1.5em;
}

body.narrow .chapter {
  width: 400px;
}

.hidden
{
	display: none;
}

#switcher .hover
{
	cursor: pointer;
	background-color: #afa;
}
</style>

    <script src="../js/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            $('#switcher .button').addClass('mouseout');
            
        $('#switcher-default').bind('click', function(event){
            $('body').removeClass('narrow');
            $('body').removeClass('large');
            $('#switcher .button').removeClass('selected');
            $(this).addClass('selected');
            //event.stopPropagation();
            });
        $('#switcher-narrow').bind('click', function(event){
            $('body').removeClass('large');
            $('body').addClass('narrow');
            $('#switcher .button').removeClass('selected');
            $(this).addClass('selected');
            //event.stopPropagation();
            });
        $('#switcher-large').bind('click', function(event){
            $('body').removeClass('narrow');
            $('body').addClass('large');
            $('#switcher .button').removeClass('selected');
            $(this).addClass('selected');
            //event.stopPropagation();
            });
            
            });
        $(document).ready(function(){
            var toggle_func=function(event){
             if(!$(event.target).is('.button'))
                    {
                        $('#switcher .button').toggleClass('hidden');
                    }
                    };
          
             $('#switcher').click(toggle_func);
              $('#switcher .button').hover(function()
              {
                    $(this).addClass('hover');
                    }, function(){
                    $(this).removeClass('hover');
                    });
                    
                      $('#switcher').trigger('click');
                      
                      $(document).keyup(function(event){
                        switch(String.fromCharCode(event.keyCode))
                        {
                            case 'D':
                                $('#switcher-default').click();
                                break;
                            case 'N':
                                $('#switcher-narrow').click();
                                break;
                            case 'L':
                                $('#switcher-large').click();
                                break;
                            default:
                                break;
                        }
                        });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="container">

      <div id="switcher">
        <h3>Style Switcher</h3>
        <div class="button selected" id="switcher-default">
          Default
        </div>
        <div class="button" id="switcher-narrow">
          Narrow Column
        </div>
        <div class="button" id="switcher-large">
          Large Print
        </div>
      </div>

      <div id="header">
        <h2>A Christmas Carol</h2>
        <h2 class="subtitle">In Prose, Being a Ghost Story of Christmas</h2>
        <div class="author">by Charles Dickens</div>
      </div>
      
      <div class="chapter" id="chapter-preface">
        <h3 class="chapter-title">Preface</h3>
        <p>I HAVE endeavoured in this Ghostly little book, to raise the Ghost of an Idea, which shall not put my readers out of humour with themselves, with each other, with the season, or with me.  May it haunt their houses pleasantly, and no one wish to lay it.</p>
        <p>Their faithful Friend and Servant,</p>
        <p>C. D.</p>
        <p>December, 1843.</p>
      </div>
      
      <div class="chapter" id="chapter-1">
        <h3 class="chapter-title">Stave I: Marley's Ghost</h3>
        <p>MARLEY was dead: to begin with. There is no doubt whatever about that. The register of his burial was signed by the clergyman, the clerk, the undertaker, and the chief mourner. Scrooge signed it: and Scrooge's name was good upon 'Change, for anything he chose to put his hand to. Old Marley was as dead as a door-nail.</p>
        <p>Mind! I don't mean to say that I know, of my own knowledge, what there is particularly dead about a door-nail. I might have been inclined, myself, to regard a coffin-nail as the deadest piece of ironmongery in the trade. But the wisdom of our ancestors is in the simile; and my unhallowed hands shall not disturb it, or the Country's done for. You will therefore permit me to repeat, emphatically, that Marley was as dead as a door-nail.</p>
        <p>Scrooge knew he was dead? Of course he did. How could it be otherwise? Scrooge and he were partners for I don't know how many years. Scrooge was his sole executor, his sole administrator, his sole assign, his sole residuary legatee, his sole friend, and sole mourner. And even Scrooge was not so dreadfully cut up by the sad event, but that he was an excellent man of business on the very day of the funeral, and solemnised it with an undoubted bargain.</p>
        <p>The mention of Marley's funeral brings me back to the point I started from. There is no doubt that Marley was dead. This must be distinctly understood, or nothing wonderful can come of the story I am going to relate. If we were not perfectly convinced that Hamlet's Father died before the play began, there would be nothing more remarkable in his taking a stroll at night, in an easterly wind, upon his own ramparts, than there would be in any other middle-aged gentleman rashly turning out after dark in a breezy spot&mdash;say Saint Paul's Churchyard for instance&mdash; literally to astonish his son's weak mind.</p>
        <p>Scrooge never painted out Old Marley's name. There it stood, years afterwards, above the warehouse door: Scrooge and Marley. The firm was known as Scrooge and Marley. Sometimes people new to the business called Scrooge Scrooge, and sometimes Marley, but he answered to both names. It was all the same to him.</p>
        <p>Oh! But he was a tight-fisted hand at the grind-stone, Scrooge! a squeezing, wrenching, grasping, scraping, clutching, covetous, old sinner! Hard and sharp as flint, from which no steel had ever struck out generous fire; secret, and self-contained, and solitary as an oyster. The cold within him froze his old features, nipped his pointed nose, shrivelled his cheek, stiffened his gait; made his eyes red, his thin lips blue; and spoke out shrewdly in his grating voice. A frosty rime was on his head, and on his eyebrows, and his wiry chin. He carried his own low temperature always about with him; he iced his office in the dog-days; and didn't thaw it one degree at Christmas.</p>
        <p>External heat and cold had little influence on Scrooge. No warmth could warm, no wintry weather chill him. No wind that blew was bitterer than he, no falling snow was more intent upon its purpose, no pelting rain less open to entreaty. Foul weather didn't know where to have him. The heaviest rain, and snow, and hail, and sleet, could boast of the advantage over him in only one respect. They often "came down" handsomely, and Scrooge never did.</p>
        <p>Nobody ever stopped him in the street to say, with gladsome looks, "My dear Scrooge, how are you? When will you come to see me?" No beggars implored him to bestow a trifle, no children asked him what it was o'clock, no man or woman ever once in all his life inquired the way to such and such a place, of Scrooge. Even the blind men's dogs appeared to know him; and when they saw him coming on, would tug their owners into doorways and up courts; and then would wag their tails as though they said, "No eye at all is better than an evil eye, dark master!"</p>
        <p>But what did Scrooge care! It was the very thing he liked. To edge his way along the crowded paths of life, warning all human sympathy to keep its distance, was what the knowing ones call "nuts" to Scrooge.</p>
        <p>Once upon a time&mdash;of all the good days in the year, on Christmas Eve&mdash;old Scrooge sat busy in his counting-house. It was cold, bleak, biting weather: foggy withal: and he could hear the people in the court outside, go wheezing up and down, beating their hands upon their breasts, and stamping their feet upon the pavement stones to warm them. The city clocks had only just gone three, but it was quite dark already&mdash; it had not been light all day&mdash;and candles were flaring in the windows of the neighbouring offices, like ruddy smears upon the palpable brown air. The fog came pouring in at every chink and keyhole, and was so dense without, that although the court was of the narrowest, the houses opposite were mere phantoms. To see the dingy cloud come drooping down, obscuring everything, one might have thought that Nature lived hard by, and was brewing on a large scale.</p>
        <p>The door of Scrooge's counting-house was open that he might keep his eye upon his clerk, who in a dismal little cell beyond, a sort of tank, was copying letters. Scrooge had a very small fire, but the clerk's fire was so very much smaller that it looked like one coal. But he couldn't replenish it, for Scrooge kept the coal-box in his own room; and so surely as the clerk came in with the shovel, the master predicted that it would be necessary for them to part. Wherefore the clerk put on his white comforter, and tried to warm himself at the candle; in which effort, not being a man of a strong imagination, he failed.</p>
        <p>"A merry Christmas, uncle! God save you!" cried a cheerful voice. It was the voice of Scrooge's nephew, who came upon him so quickly that this was the first intimation he had of his approach.</p>
        <p>"Bah!" said Scrooge, "Humbug!"</p>
        <p>He had so heated himself with rapid walking in the fog and frost, this nephew of Scrooge's, that he was all in a glow; his face was ruddy and handsome; his eyes sparkled, and his breath smoked again.</p>
        <p>"Christmas a humbug, uncle!" said Scrooge's nephew. "You don't mean that, I am sure?"</p>
        <p>"I do," said Scrooge. "Merry Christmas! What right have you to be merry? What reason have you to be merry? You're poor enough."</p>
        <p>"Come, then," returned the nephew gaily. "What right have you to be dismal? What reason have you to be morose? You're rich enough."</p>
        <p>Scrooge having no better answer ready on the spur of the moment, said, "Bah!" again; and followed it up with "Humbug."</p>
        <p>"Don't be cross, uncle!" said the nephew.</p>
        <p>"What else can I be," returned the uncle, "when I live in such a world of fools as this? Merry Christmas! Out upon merry Christmas! What's Christmas time to you but a time for paying bills without money; a time for finding yourself a year older, but not an hour richer; a time for balancing your books and having every item in 'em through a round dozen of months presented dead against you? If I could work my will," said Scrooge indignantly, "every idiot who goes about with 'Merry Christmas' on his lips, should be boiled with his own pudding, and buried with a stake of holly through his heart. He should!"</p>
        <p>"Uncle!" pleaded the nephew.</p>
        <p>"Nephew!" returned the uncle sternly, "keep Christmas in your own way, and let me keep it in mine."</p>
        <p>"Keep it!" repeated Scrooge's nephew. "But you don't keep it."</p>
        <p>"Let me leave it alone, then," said Scrooge. "Much good may it do you! Much good it has ever done you!"</p>
        <p>"There are many things from which I might have derived good, by which I have not profited, I dare say," returned the nephew. "Christmas among the rest. But I am sure I have always thought of Christmas time, when it has come round&mdash;apart from the veneration due to its sacred name and origin, if anything belonging to it can be apart from that&mdash;as a good time; a kind, forgiving, charitable, pleasant time; the only time I know of, in the long calendar of the year, when men and women seem by one consent to open their shut-up hearts freely, and to think of people below them as if they really were fellow-passengers to the grave, and not another race of creatures bound on other journeys. And therefore, uncle, though it has never put a scrap of gold or silver in my pocket, I believe that it has done me good, and will do me good; and I say, God bless it!"</p>
        <p>The clerk in the Tank involuntarily applauded. Becoming immediately sensible of the impropriety, he poked the fire, and extinguished the last frail spark for ever.</p>
        <p>"Let me hear another sound from you," said Scrooge, "and you'll keep your Christmas by losing your situation! You're quite a powerful speaker, sir," he added, turning to his nephew. "I wonder you don't go into Parliament."</p>
        <p>"Don't be angry, uncle. Come! Dine with us to-morrow."</p>
        <p>Scrooge said that he would see him&mdash;yes, indeed he did. He went the whole length of the expression, and said that he would see him in that extremity first.</p>
        <p>"But why?" cried Scrooge's nephew. "Why?"</p>
        <p>"Why did you get married?" said Scrooge.</p>
        <p>"Because I fell in love."</p>
        <p>"Because you fell in love!" growled Scrooge, as if that were the only one thing in the world more ridiculous than a merry Christmas. "Good afternoon!"</p>
        <p>"Nay, uncle, but you never came to see me before that happened. Why give it as a reason for not coming now?"</p>
        <p>"Good afternoon," said Scrooge.</p>
        <p>"I want nothing from you; I ask nothing of you; why cannot we be friends?"</p>
        <p>"Good afternoon," said Scrooge.</p>
        <p>"I am sorry, with all my heart, to find you so resolute. We have never had any quarrel, to which I have been a party. But I have made the trial in homage to Christmas, and I'll keep my Christmas humour to the last. So A Merry Christmas, uncle!"</p>
        <p>"Good afternoon!" said Scrooge.</p>
        <p>"And A Happy New Year!"</p>
        <p>"Good afternoon!" said Scrooge.</p>
        <p>His nephew left the room without an angry word, notwithstanding. He stopped at the outer door to bestow the greetings of the season on the clerk, who, cold as he was, was warmer than Scrooge; for he returned them cordially.</p>
        <p>"There's another fellow," muttered Scrooge; who overheard him: "my clerk, with fifteen shillings a week, and a wife and family, talking about a merry Christmas. I'll retire to Bedlam."</p>
        <p>This lunatic, in letting Scrooge's nephew out, had let two other people in. They were portly gentlemen, pleasant to behold, and now stood, with their hats off, in Scrooge's office. They had books and papers in their hands, and bowed to him.</p>
        <p>"Scrooge and Marley's, I believe," said one of the gentlemen, referring to his list. "Have I the pleasure of addressing Mr. Scrooge, or Mr. Marley?"</p>
        <p>"Mr. Marley has been dead these seven years," Scrooge replied. "He died seven years ago, this very night."</p>
        <p>"We have no doubt his liberality is well represented by his surviving partner," said the gentleman, presenting his credentials.</p>
        <p>It certainly was; for they had been two kindred spirits. At the ominous word "liberality," Scrooge frowned, and shook his head, and handed the credentials back.</p>
        <p>"At this festive season of the year, Mr. Scrooge," said the gentleman, taking up a pen, "it is more than usually desirable that we should make some slight provision for the Poor and destitute, who suffer greatly at the present time. Many thousands are in want of common necessaries; hundreds of thousands are in want of common comforts, sir."</p>
        <p>"Are there no prisons?" asked Scrooge.</p>
        <p>"Plenty of prisons," said the gentleman, laying down the pen again.</p>
        <p>"And the Union workhouses?" demanded Scrooge. "Are they still in operation?"</p>
        <p>"They are. Still," returned the gentleman, "I wish I could say they were not."</p>
        <p>"The Treadmill and the Poor Law are in full vigour, then?" said Scrooge.</p>
        <p>"Both very busy, sir."</p>
        <p>"Oh! I was afraid, from what you said at first, that something had occurred to stop them in their useful course," said Scrooge. "I'm very glad to hear it."</p>
        <p>"Under the impression that they scarcely furnish Christian cheer of mind or body to the multitude," returned the gentleman, "a few of us are endeavouring to raise a fund to buy the Poor some meat and drink, and means of warmth. We choose this time, because it is a time, of all others, when Want is keenly felt, and Abundance rejoices. What shall I put you down for?"</p>
        <p>"Nothing!" Scrooge replied.</p>
        <p>"You wish to be anonymous?"</p>
        <p>"I wish to be left alone," said Scrooge. "Since you ask me what I wish, gentlemen, that is my answer. I don't make merry myself at Christmas and I can't afford to make idle people merry. I help to support the establishments I have mentioned&mdash;they cost enough; and those who are badly off must go there."</p>
        <p>"Many can't go there; and many would rather die."</p>
        <p>"If they would rather die," said Scrooge, "they had better do it, and decrease the surplus population. Besides&mdash;excuse me&mdash;I don't know that."</p>
        <p>"But you might know it," observed the gentleman.</p>
        <p>"It's not my business," Scrooge returned. "It's enough for a man to understand his own business, and not to interfere with other people's. Mine occupies me constantly. Good afternoon, gentlemen!"</p>
        <p>Seeing clearly that it would be useless to pursue their point, the gentlemen withdrew. Scrooge resumed his labours with an improved opinion of himself, and in a more facetious temper than was usual with him.</p>
        <p>Meanwhile the fog and darkness thickened so, that people ran about with flaring links, proffering their services to go before horses in carriages, and conduct them on their way. The ancient tower of a church, whose gruff old bell was always peeping slily down at Scrooge out of a Gothic window in the wall, became invisible, and struck the hours and quarters in the clouds, with tremulous vibrations afterwards as if its teeth were chattering in its frozen head up there. The cold became intense. In the main street, at the corner of the court, some labourers were repairing the gas-pipes, and had lighted a great fire in a brazier, round which a party of ragged men and boys were gathered: warming their hands and winking their eyes before the blaze in rapture. The water-plug being left in solitude, its overflowings sullenly congealed, and turned to misanthropic ice. The brightness of the shops where holly sprigs and berries crackled in the lamp heat of the windows, made pale faces ruddy as they passed. Poulterers' and grocers' trades became a splendid joke: a glorious pageant, with which it was next to impossible to believe that such dull principles as bargain and sale had anything to do. The Lord Mayor, in the stronghold of the mighty Mansion House, gave orders to his fifty cooks and butlers to keep Christmas as a Lord Mayor's household should; and even the little tailor, whom he had fined five shillings on the previous Monday for being drunk and bloodthirsty in the streets, stirred up to-morrow's pudding in his garret, while his lean wife and the baby sallied out to buy the beef.</p>
        <p>Foggier yet, and colder. Piercing, searching, biting cold. If the good Saint Dunstan had but nipped the Evil Spirit's nose with a touch of such weather as that, instead of using his familiar weapons, then indeed he would have roared to lusty purpose. The owner of one scant young nose, gnawed and mumbled by the hungry cold as bones are gnawed by dogs, stooped down at Scrooge's keyhole to regale him with a Christmas carol: but at the first sound of</p>
        <div class="poem">
          <div class="poem-line">"God bless you, merry gentleman!</div>
          <div class="poem-line">May nothing you dismay!"</div>
        </div>
        <p>Scrooge seized the ruler with such energy of action, that the singer fled in terror, leaving the keyhole to the fog and even more congenial frost.</p>
        <p>At length the hour of shutting up the counting-house arrived. With an ill-will Scrooge dismounted from his stool, and tacitly admitted the fact to the expectant clerk in the Tank, who instantly snuffed his candle out, and put on his hat.</p>
        <p>"You'll want all day to-morrow, I suppose?" said Scrooge.</p>
        <p>"If quite convenient, sir."</p>
        <p>"It's not convenient," said Scrooge, "and it's not fair. If I was to stop half-a-crown for it, you'd think yourself ill-used, I'll be bound?"</p>
        <p>The clerk smiled faintly.</p>
        <p>"And yet," said Scrooge, "you don't think me ill-used, when I pay a day's wages for no work."</p>
        <p>The clerk observed that it was only once a year.</p>
        <p>"A poor excuse for picking a man's pocket every twenty-fifth of December!" said Scrooge, buttoning his great-coat to the chin. "But I suppose you must have the whole day. Be here all the earlier next morning."</p>
        <p>The clerk promised that he would; and Scrooge walked out with a growl. The office was closed in a twinkling, and the clerk, with the long ends of his white comforter dangling below his waist (for he boasted no great-coat), went down a slide on Cornhill, at the end of a lane of boys, twenty times, in honour of its being Christmas Eve, and then ran home to Camden Town as hard as he could pelt, to play at blindman's-buff.</p>
        <p>Scrooge took his melancholy dinner in his usual melancholy tavern; and having read all the newspapers, and beguiled the rest of the evening with his banker's-book, went home to bed. He lived in chambers which had once belonged to his deceased partner. They were a gloomy suite of rooms, in a lowering pile of building up a yard, where it had so little business to be, that one could scarcely help fancying it must have run there when it was a young house, playing at hide-and-seek with other houses, and forgotten the way out again. It was old enough now, and dreary enough, for nobody lived in it but Scrooge, the other rooms being all let out as offices. The yard was so dark that even Scrooge, who knew its every stone, was fain to grope with his hands. The fog and frost so hung about the black old gateway of the house, that it seemed as if the Genius of the Weather sat in mournful meditation on the threshold.</p>
        <p>Now, it is a fact, that there was nothing at all particular about the knocker on the door, except that it was very large. It is also a fact, that Scrooge had seen it, night and morning, during his whole residence in that place; also that Scrooge had as little of what is called fancy about him as any man in the city of London, even including&mdash;which is a bold word&mdash;the corporation, aldermen, and livery. Let it also be borne in mind that Scrooge had not bestowed one thought on Marley, since his last mention of his seven years' dead partner that afternoon. And then let any man explain to me, if he can, how it happened that Scrooge, having his key in the lock of the door, saw in the knocker, without its undergoing any intermediate process of change&mdash;not a knocker, but Marley's face.</p>
        <p>Marley's face. It was not in impenetrable shadow as the other objects in the yard were, but had a dismal light about it, like a bad lobster in a dark cellar. It was not angry or ferocious, but looked at Scrooge as Marley used to look: with ghostly spectacles turned up on its ghostly forehead. The hair was curiously stirred, as if by breath or hot air; and, though the eyes were wide open, they were perfectly motionless. That, and its livid colour, made it horrible; but its horror seemed to be in spite of the face and beyond its control, rather than a part of its own expression.</p>
        <p>As Scrooge looked fixedly at this phenomenon, it was a knocker again.</p>
        <p>To say that he was not startled, or that his blood was not conscious of a terrible sensation to which it had been a stranger from infancy, would be untrue. But he put his hand upon the key he had relinquished, turned it sturdily, walked in, and lighted his candle.</p>
        <p>He did pause, with a moment's irresolution, before he shut the door; and he did look cautiously behind it first, as if he half expected to be terrified with the sight of Marley's pigtail sticking out into the hall. But there was nothing on the back of the door, except the screws and nuts that held the knocker on, so he said "Pooh, pooh!" and closed it with a bang.</p>
        <p>The sound resounded through the house like thunder. Every room above, and every cask in the wine-merchant's cellars below, appeared to have a separate peal of echoes of its own. Scrooge was not a man to be frightened by echoes. He fastened the door, and walked across the hall, and up the stairs; slowly too: trimming his candle as he went.</p>
        <p>You may talk vaguely about driving a coach-and-six up a good old flight of stairs, or through a bad young Act of Parliament; but I mean to say you might have got a hearse up that staircase, and taken it broadwise, with the splinter-bar towards the wall and the door towards the balustrades: and done it easy. There was plenty of width for that, and room to spare; which is perhaps the reason why Scrooge thought he saw a locomotive hearse going on before him in the gloom. Half-a-dozen gas-lamps out of the street wouldn't have lighted the entry too well, so you may suppose that it was pretty dark with Scrooge's dip.</p>
        <p>Up Scrooge went, not caring a button for that. Darkness is cheap, and Scrooge liked it. But before he shut his heavy door, he walked through his rooms to see that all was right. He had just enough recollection of the face to desire to do that.</p>
        <p>Sitting-room, bedroom, lumber-room. All as they should be. Nobody under the table, nobody under the sofa; a small fire in the grate; spoon and basin ready; and the little saucepan of gruel (Scrooge had a cold in his head) upon the hob. Nobody under the bed; nobody in the closet; nobody in his dressing-gown, which was hanging up in a suspicious attitude against the wall. Lumber-room as usual. Old fire-guard, old shoes, two fish-baskets, washing-stand on three legs, and a poker.</p>
        <p>Quite satisfied, he closed his door, and locked himself in; double-locked himself in, which was not his custom. Thus secured against surprise, he took off his cravat; put on his dressing-gown and slippers, and his nightcap; and sat down before the fire to take his gruel.</p>
        <p>It was a very low fire indeed; nothing on such a bitter night. He was obliged to sit close to it, and brood over it, before he could extract the least sensation of warmth from such a handful of fuel. The fireplace was an old one, built by some Dutch merchant long ago, and paved all round with quaint Dutch tiles, designed to illustrate the Scriptures. There were Cains and Abels, Pharaoh's daughters; Queens of Sheba, Angelic messengers descending through the air on clouds like feather-beds, Abrahams, Belshazzars, Apostles putting off to sea in butter-boats, hundreds of figures to attract his thoughts; and yet that face of Marley, seven years dead, came like the ancient Prophet's rod, and swallowed up the whole. If each smooth tile had been a blank at first, with power to shape some picture on its surface from the disjointed fragments of his thoughts, there would have been a copy of old Marley's head on every one.</p>
        <p>"Humbug!" said Scrooge; and walked across the room.</p>
        <p>After several turns, he sat down again. As he threw his head back in the chair, his glance happened to rest upon a bell, a disused bell, that hung in the room, and communicated for some purpose now forgotten with a chamber in the highest story of the building. It was with great astonishment, and with a strange, inexplicable dread, that as he looked, he saw this bell begin to swing. It swung so softly in the outset that it scarcely made a sound; but soon it rang out loudly, and so did every bell in the house.</p>
        <p>This might have lasted half a minute, or a minute, but it seemed an hour. The bells ceased as they had begun, together. They were succeeded by a clanking noise, deep down below; as if some person were dragging a heavy chain over the casks in the wine-merchant's cellar. Scrooge then remembered to have heard that ghosts in haunted houses were described as dragging chains.</p>
        <p>The cellar-door flew open with a booming sound, and then he heard the noise much louder, on the floors below; then coming up the stairs; then coming straight towards his door.</p>
        <p>"It's humbug still!" said Scrooge. "I won't believe it."</p>
        <p>His colour changed though, when, without a pause, it came on through the heavy door, and passed into the room before his eyes. Upon its coming in, the dying flame leaped up, as though it cried, "I know him; Marley's Ghost!" and fell again.</p>
        <p>The same face: the very same. Marley in his pigtail, usual waistcoat, tights and boots; the tassels on the latter bristling, like his pigtail, and his coat-skirts, and the hair upon his head. The chain he drew was clasped about his middle. It was long, and wound about him like a tail; and it was made (for Scrooge observed it closely) of cash-boxes, keys, padlocks, ledgers, deeds, and heavy purses wrought in steel. His body was transparent; so that Scrooge, observing him, and looking through his waistcoat, could see the two buttons on his coat behind.</p>
        <p>Scrooge had often heard it said that Marley had no bowels, but he had never believed it until now.</p>
        <p>No, nor did he believe it even now. Though he looked the phantom through and through, and saw it standing before him; though he felt the chilling influence of its death-cold eyes; and marked the very texture of the folded kerchief bound about its head and chin, which wrapper he had not observed before; he was still incredulous, and fought against his senses.</p>
        <p>"How now!" said Scrooge, caustic and cold as ever. "What do you want with me?"</p>
        <p>"Much!"&mdash;Marley's voice, no doubt about it.</p>
        <p>"Who are you?"</p>
        <p>"Ask me who I was."</p>
        <p>"Who were you then?" said Scrooge, raising his voice. "You're particular, for a shade." He was going to say "to a shade," but substituted this, as more appropriate.</p>
        <p>"In life I was your partner, Jacob Marley."</p>
        <p>"Can you&mdash;can you sit down?" asked Scrooge, looking doubtfully at him.</p>
        <p>"I can."</p>
        <p>"Do it, then."</p>
        <p>Scrooge asked the question, because he didn't know whether a ghost so transparent might find himself in a condition to take a chair; and felt that in the event of its being impossible, it might involve the necessity of an embarrassing explanation. But the ghost sat down on the opposite side of the fireplace, as if he were quite used to it.</p>
        <p>"You don't believe in me," observed the Ghost.</p>
        <p>"I don't," said Scrooge.</p>
        <p>"What evidence would you have of my reality beyond that of your senses?"</p>
        <p>"I don't know," said Scrooge.</p>
        <p>"Why do you doubt your senses?"</p>
        <p>"Because," said Scrooge, "a little thing affects them. A slight disorder of the stomach makes them cheats. You may be an undigested bit of beef, a blot of mustard, a crumb of cheese, a fragment of an underdone potato. There's more of gravy than of grave about you, whatever you are!"</p>
        <p>Scrooge was not much in the habit of cracking jokes, nor did he feel, in his heart, by any means waggish then. The truth is, that he tried to be smart, as a means of distracting his own attention, and keeping down his terror; for the spectre's voice disturbed the very marrow in his bones.</p>
        <p>To sit, staring at those fixed glazed eyes, in silence for a moment, would play, Scrooge felt, the very deuce with him. There was something very awful, too, in the spectre's being provided with an infernal atmosphere of its own. Scrooge could not feel it himself, but this was clearly the case; for though the Ghost sat perfectly motionless, its hair, and skirts, and tassels, were still agitated as by the hot vapour from an oven.</p>
        <p>"You see this toothpick?" said Scrooge, returning quickly to the charge, for the reason just assigned; and wishing, though it were only for a second, to divert the vision's stony gaze from himself.</p>
        <p>"I do," replied the Ghost.</p>
        <p>"You are not looking at it," said Scrooge.</p>
        <p>"But I see it," said the Ghost, "notwithstanding."</p>
        <p>"Well!" returned Scrooge, "I have but to swallow this, and be for the rest of my days persecuted by a legion of goblins, all of my own creation. Humbug, I tell you! humbug!"</p>
        <p>At this the spirit raised a frightful cry, and shook its chain with such a dismal and appalling noise, that Scrooge held on tight to his chair, to save himself from falling in a swoon. But how much greater was his horror, when the phantom taking off the bandage round its head, as if it were too warm to wear indoors, its lower jaw dropped down upon its breast!</p>
        <p>Scrooge fell upon his knees, and clasped his hands before his face.</p>
        <p>"Mercy!" he said. "Dreadful apparition, why do you trouble me?"</p>
        <p>"Man of the worldly mind!" replied the Ghost, "do you believe in me or not?"</p>
        <p>"I do," said Scrooge. "I must. But why do spirits walk the earth, and why do they come to me?"</p>
        <p>"It is required of every man," the Ghost returned, "that the spirit within him should walk abroad among his fellowmen, and travel far and wide; and if that spirit goes not forth in life, it is condemned to do so after death. It is doomed to wander through the world&mdash;oh, woe is me!&mdash;and witness what it cannot share, but might have shared on earth, and turned to happiness!"</p>
        <p>Again the spectre raised a cry, and shook its chain and wrung its shadowy hands.</p>
        <p>"You are fettered," said Scrooge, trembling. "Tell me why?"</p>
        <p>"I wear the chain I forged in life," replied the Ghost. "I made it link by link, and yard by yard; I girded it on of my own free will, and of my own free will I wore it. Is its pattern strange to you?"</p>
        <p>Scrooge trembled more and more.</p>
        <p>"Or would you know," pursued the Ghost, "the weight and length of the strong coil you bear yourself? It was full as heavy and as long as this, seven Christmas Eves ago. You have laboured on it, since. It is a ponderous chain!"</p>
        <p>Scrooge glanced about him on the floor, in the expectation of finding himself surrounded by some fifty or sixty fathoms of iron cable: but he could see nothing.</p>
        <p>"Jacob," he said, imploringly. "Old Jacob Marley, tell me more. Speak comfort to me, Jacob!"</p>
        <p>"I have none to give," the Ghost replied. "It comes from other regions, Ebenezer Scrooge, and is conveyed by other ministers, to other kinds of men. Nor can I tell you what I would. A very little more is all permitted to me. I cannot rest, I cannot stay, I cannot linger anywhere. My spirit never walked beyond our counting-house&mdash;mark me!&mdash;in life my spirit never roved beyond the narrow limits of our money-changing hole; and weary journeys lie before me!"</p>
        <p>It was a habit with Scrooge, whenever he became thoughtful, to put his hands in his breeches pockets. Pondering on what the Ghost had said, he did so now, but without lifting up his eyes, or getting off his knees.</p>
        <p>"You must have been very slow about it, Jacob," Scrooge observed, in a business-like manner, though with humility and deference.</p>
        <p>"Slow!" the Ghost repeated.</p>
        <p>"Seven years dead," mused Scrooge. "And travelling all the time!"</p>
        <p>"The whole time," said the Ghost. "No rest, no peace. Incessant torture of remorse."</p>
        <p>"You travel fast?" said Scrooge.</p>
        <p>"On the wings of the wind," replied the Ghost.</p>
        <p>"You might have got over a great quantity of ground in seven years," said Scrooge.</p>
        <p>The Ghost, on hearing this, set up another cry, and clanked its chain so hideously in the dead silence of the night, that the Ward would have been justified in indicting it for a nuisance.</p>
        <p>"Oh! captive, bound, and double-ironed," cried the phantom, "not to know, that ages of incessant labour by immortal creatures, for this earth must pass into eternity before the good of which it is susceptible is all developed. Not to know that any Christian spirit working kindly in its little sphere, whatever it may be, will find its mortal life too short for its vast means of usefulness. Not to know that no space of regret can make amends for one life's opportunity misused! Yet such was I! Oh! such was I!"</p>
        <p>"But you were always a good man of business, Jacob," faltered Scrooge, who now began to apply this to himself.</p>
        <p>"Business!" cried the Ghost, wringing its hands again. "Mankind was my business. The common welfare was my business; charity, mercy, forbearance, and benevolence, were, all, my business. The dealings of my trade were but a drop of water in the comprehensive ocean of my business!"</p>
        <p>It held up its chain at arm's length, as if that were the cause of all its unavailing grief, and flung it heavily upon the ground again.</p>
        <p>"At this time of the rolling year," the spectre said, "I suffer most. Why did I walk through crowds of fellow-beings with my eyes turned down, and never raise them to that blessed Star which led the Wise Men to a poor abode! Were there no poor homes to which its light would have conducted me!"</p>
        <p>Scrooge was very much dismayed to hear the spectre going on at this rate, and began to quake exceedingly.</p>
        <p>"Hear me!" cried the Ghost. "My time is nearly gone."</p>
        <p>"I will," said Scrooge. "But don't be hard upon me! Don't be flowery, Jacob! Pray!"</p>
        <p>"How it is that I appear before you in a shape that you can see, I may not tell. I have sat invisible beside you many and many a day."</p>
        <p>It was not an agreeable idea. Scrooge shivered, and wiped the perspiration from his brow.</p>
        <p>"That is no light part of my penance," pursued the Ghost. "I am here to-night to warn you, that you have yet a chance and hope of escaping my fate. A chance and hope of my procuring, Ebenezer."</p>
        <p>"You were always a good friend to me," said Scrooge. "Thank'ee!"</p>
        <p>"You will be haunted," resumed the Ghost, "by Three Spirits."</p>
        <p>Scrooge's countenance fell almost as low as the Ghost's had done.</p>
        <p>"Is that the chance and hope you mentioned, Jacob?" he demanded, in a faltering voice.</p>
        <p>"It is."</p>
        <p>"I&mdash;I think I'd rather not," said Scrooge.</p>
        <p>"Without their visits," said the Ghost, "you cannot hope to shun the path I tread. Expect the first to-morrow, when the bell tolls One."</p>
        <p>"Couldn't I take 'em all at once, and have it over, Jacob?" hinted Scrooge.</p>
        <p>"Expect the second on the next night at the same hour. The third upon the next night when the last stroke of Twelve has ceased to vibrate. Look to see me no more; and look that, for your own sake, you remember what has passed between us!"</p>
        <p>When it had said these words, the spectre took its wrapper from the table, and bound it round its head, as before. Scrooge knew this, by the smart sound its teeth made, when the jaws were brought together by the bandage. He ventured to raise his eyes again, and found his supernatural visitor confronting him in an erect attitude, with its chain wound over and about its arm.</p>
        <p>The apparition walked backward from him; and at every step it took, the window raised itself a little, so that when the spectre reached it, it was wide open.</p>
        <p>It beckoned Scrooge to approach, which he did. When they were within two paces of each other, Marley's Ghost held up its hand, warning him to come no nearer. Scrooge stopped.</p>
        <p>Not so much in obedience, as in surprise and fear: for on the raising of the hand, he became sensible of confused noises in the air; incoherent sounds of lamentation and regret; wailings inexpressibly sorrowful and self-accusatory. The spectre, after listening for a moment, joined in the mournful dirge; and floated out upon the bleak, dark night.</p>
        <p>Scrooge followed to the window: desperate in his curiosity. He looked out.</p>
        <p>The air was filled with phantoms, wandering hither and thither in restless haste, and moaning as they went. Every one of them wore chains like Marley's Ghost; some few (they might be guilty governments) were linked together; none were free. Many had been personally known to Scrooge in their lives. He had been quite familiar with one old ghost, in a white waistcoat, with a monstrous iron safe attached to its ankle, who cried piteously at being unable to assist a wretched woman with an infant, whom it saw below, upon a door-step. The misery with them all was, clearly, that they sought to interfere, for good, in human matters, and had lost the power for ever.</p>
        <p>Whether these creatures faded into mist, or mist enshrouded them, he could not tell. But they and their spirit voices faded together; and the night became as it had been when he walked home.</p>
        <p>Scrooge closed the window, and examined the door by which the Ghost had entered. It was double-locked, as he had locked it with his own hands, and the bolts were undisturbed. He tried to say "Humbug!" but stopped at the first syllable. And being, from the emotion he had undergone, or the fatigues of the day, or his glimpse of the Invisible World, or the dull conversation of the Ghost, or the lateness of the hour, much in need of repose; went straight to bed, without undressing, and fell asleep upon the instant.</p>
      </div>
    </div>
</asp:Content>
