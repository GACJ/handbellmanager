<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<meta name="description" content="A dummy handbell interface to Abel change ringing simulator" />
	<meta name="keywords" content="changeringing ringing dummy handbell manager handbellmanager motion controller sensor ActionXL Abel simulator" />
	<meta name="author" content="Graham John" />
	<link rel="stylesheet" type="text/css" href="complib.css" media="screen,projection" />
	<title>Handbell Manager - <?php echo $title ?></title>
</head>
<script language="javascript" src="email.js" type="text/javascript"></script>
<body>
<div id="wrap">

	<div id="header">
		<h1><a href="index.php">Handbell Manager</a></h1>
		<p>The dummy handbell interface for Abel. <a href="print.html"></a></p>
	</div>

	<img id="frontphoto" src="img/banner.png" width="760" height="239" alt="" />

	<div id="leftside">
		<h2 class="hide">Menu:</h2>
		
		<ul class="avmenu">
			<?php

			$output = '<li><a ';
			if ($title == 'Introduction') $output .= 'class="current" ';
			$output .= 'href="index.php">Introduction</a></li>';
			echo $output;

			$output = '<li><a ';
			if ($title == 'Background') $output .= 'class="current" ';
			$output .= 'href="background.php">Background</a></li>';
			echo $output;

			$output = '<li><a ';
			if ($title == 'Features') $output .= 'class="current" ';
			$output .= 'href="HMHelp.htm">Features</a></li>';
			echo $output;
			
			$output = '<li><a ';
			if ($title == 'Improving the Experience') $output .= 'class="current" ';
			$output .= 'href="improvements.php">Improvements</a></li>';
			echo $output;
			
			?>
		</ul>
		
		<div class="announce">
			<h2><u>Updates:</u></h2>
			<p><strong>Aug 25, 2009:</strong><br />Handbell Manager v1.1 released.</p>
			<p><strong>Aug 19, 2009:</strong><br />Improvements section added to site.</p>
			<p><strong>Aug 15, 2009:</strong><br />Handbell Manager v1.0 released.</p>
			<p><a href="http://sourceforge.net/projects/handbellmanager">Sourceforge &raquo;</a></p>
			<p><a href="http://www.abelsim.co.uk">Abel Simulator &raquo;</a></p>
			<p><a href="http://www.actionxl.com">ActionXL Motion Controllers &raquo;</a></p>
		</div>
	</div>

	<div id="contentwide">
	
