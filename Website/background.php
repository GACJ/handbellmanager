<?php

$title = 'Background';

//Include the header
include('header.php');

?>

<h2>Background</h2>

<h3>Learning methods</h3>

<p>Towerbell ringers can learn methods and test themselves quite
easily by reciting the work of a method or by drawing out the blue line on paper.
If they can do this quickly and without error, and their ropesight
is good, they can be confident that this will translate into a
reliable performance in the tower. However, for handbell ringers
it is much harder to confirm whether they know a method well enough
to ring it on handbells, because knowing a single line or a grid
pattern doesn&rsquo;t mean that you can ring two bells based upon this
knowledge. To demonstrate that you know a method by drawing it on
paper, you would have to be able to draw two lines simultaneously.
This is impracticable. The alternative, and one that some handbell
ringers use, is to practice methods with Abel simulator, using two
keys on the keyboard to ring their two bells while Abel rings the
rest.</p>

<div align=center>
<p><img src="img/Abel.png" alt="Abel Simulator" width="555" height="450" hspace="15"></p>
<p class="caption"><a target="_top" href="http://www.abelsim.co.uk">Abel Simulator</a></p>
</div>

<h3>Ringing Handbells Using the Keyboard is Hard!</h3>

<p>Some ringers seem to manage to ring Abel using the keyboard quite successfully, but it
is generally acknowledged that this is much harder than practising
with real ringers. There are a number of reasons for this, including:</p>
<ol>
<li>There is no distinction between handstroke and backstroke when
pressing keys. Using Abel&rsquo;s keyup/keydown option helps with this,
but it is no substitute for swinging one's arms up and down.</li>
<li>Using the keyboard, you cannot &ldquo;internalise&rdquo; a rhythm based
upon the movement of your arms and the timing of the swing.</li>
<li>The handbell equivalent of &ldquo;ropesight&rdquo; is difficult as Abel&rsquo;s
screen bells flip instantly between strokes. With real ringers you
see the bell you are going to follow start to move, and this helps
you anticipate the swing of your own bell to ring after it.</li>
</ol>

<h3>Dummy Handbells</h3>

<p>Abel&rsquo;s documentation suggests using dummy handbells with
electronic switches for clappers to overcome points 1 and 2,
and includes a design to help individuals build their own.
Although a few people have successfully built dummy handbells
for their own use, mechanical designs are prone to problems such
as bounce and unwanted rattle, the design is beyond many ringer&rsquo;s
DIY skills, and no one has built any for general sale to others.
Recent correspondence on ringing lists has suggested that there
is an unsatisfied demand for dummy handbells suitable for use with Abel.</p>	

<h3>Motion Controllers</h3>

<p>In recent years, motion controllers have been introduced into
console games, most notably on the Nintendo Wii, where simulation
games have been created for many action sports, using wireless motion
controllers to simulate rackets etc. Some of these Wii games
use controllers in a shaking action to simulate ringing handbells
to tunes, as shown by this Japanese video demonstrating tune ringing. 

<div align="center">
<object width="500" height="405<object width="500" height="405"><param name="movie" value="http://www.youtube-nocookie.com/v/jAAr0fh6WDQ&hl=en&fs=1&rel=0&color1=0x5d1719&color2=0xcd311b&border=1"></param><param name="allowFullScreen" value="true"></param><param name="allowscriptaccess" value="always"></param><embed src="http://www.youtube-nocookie.com/v/jAAr0fh6WDQ&hl=en&fs=1&rel=0&color1=0x5d1719&color2=0xcd311b&border=1" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="500" height="405"></embed></object>
</div>
<br>
It therefore seemed feasible that motion controllers could solve the dummy handbell problem for change ringers
too. The questions then raised were &ldquo;Are there USB motion controllers
available for PCs?&rdquo; and if there are &ldquo;How can they operate Abel?&rdquo;.
The answer to the first of these questions is &ldquo;Yes&rdquo; &mdash; at least one
company (ActionXL) makes both wired and wireless motion controllers for PCs,
and the answer to the second is now &ldquo;Yes&rdquo;, as Handbell Manager has
been developed to provide an interface to Abel.</p>
<br><br>

<div align=center>
<p><img src="img/actionxlcontrollers.png" alt="ActionXL motion controllers" width=
"581" height="240" hspace="15"></p>
<p class="caption"><a target="_top"
href="http://www.actionxl.com">Action XL Wired and Wireless Motion Controllers</a></p>
</div>

<h3>Enhancements to Abel</h3>
<p>As a result of discussions with Chris Hughes, author of Abel, during the development of Handbell Manager,
some enhancements to Abel were identified that will make ringing dummy handbells much easier. 
In particular, the introduction of moving rather than flipping handbells on screen to address point 3 above and make handbell "ropesight"
very much easier to see. Together with the use of dummy handbells, these enhancements take the experience of
ringing handbells with Abel a big step closer to the real thing.</p>
<p>For information on the availability of the latest version of Abel, see <a target="_top"
href="http://www.abelsim.co.uk">www.abelsim.co.uk</a>.</p>

<?php

include('footer.php');

?>