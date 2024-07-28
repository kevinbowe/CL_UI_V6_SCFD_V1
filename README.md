# Console - Interactive Menu
The purpose of this application is to provide a simple to use Console menu app.

This Console menu app can be used to execute other .Net C# console applications.

The Console menu app demonstrates making API calls, created with .Net core 8 - C#.

The APIs access an SQL database running in a Docker container.

The specific APIs and the Database are not required to use the Console menu app and can be easily disabled or removed.

This Console menu app can be built/compiled to run on Windows, MacOS and Unix.

This Console menu app was developed entirely with Visual Studio Code running on MacOS.


# Main Features
1. Default Main Menu options are provided and easy to customize.

2. Simple input request prompt examples are provided.

3. A default Continue / Quit menu is built in.

4. Landscape and Portrait output options are built in.

5. Color is used to focus user attention and changes dynamically based on the active menu option.

6. Asynchronous methods are supported, making API calls easy to implement.

7. This application is written in C# using .Net Core 8.

8. This application can be customized and built using Visual Studio code, running on Windows, MacOS and Unix.

9. The code base contains numerous comments which can be helpful in understanding the code and customization.

# Navigation
Navigation is 100% keyboard based.
Up and Down arrow controls position the cursor at the desired menu option.
Letters and numbers can be used to select the desired menu option.

## Cursor Wrapping.
Cursor wrapping is supported. Example:

At the bottom of a menu, selecting the Down Arrow will cause the cursor to 'wrap around' and highlight the top menu option.

At the top of a menu, selecting the Up Arrow will cause the cursor to 'wrap-around' and highlight the bottom menu option.

# Code Organization
Every effort has been made to create an application that can be used with little 'customization'. If tweaks are desired, most of the common 'tweakable bits' have been factored for easier discovery and modification.

# Code Highlights

## MENUS

<code><u>LoadHeadUI(~)</u></code>

This method contains the App header. It is simple to modify.

<code><u>MainMenuExpInit(~)</u></code>

This method initializes the main (default menu).

<code><u>DisabledList & DisabledNumList</u></code>

This lists describe menu options and numbers that should be ignored.
This list can effect cursor behavior.

<code><u>UpdatePersonFieldUI(~)</u></code>

This is a submenu that has it's own menu options, DisabledList and DisabledNumList. These menu options and disabled lists are passed to MainMenuExp(~).
The passed options 'over-rule' the default options.

## ProcessWork

The method <code><u>ProcessWork(~)</u></code> executes the option selected in the menu. This method contains a Switch/Case block that lines up with the Menu option numbers. This is completely configurable.

Edit the <code><u>ProcessWork(~)</u></code> method to add your own console commands. The existing code is for illustration and is not required for the menu app to run.

<div style="padding-left: 30px;">
	<p>
		<b>Existing - Example Methods:</b> <br>
	</p>
	<p>
	<u> <code>GetPersonsAsync(~)</code></u>, <u> <code>GetPersonByIdAsync(~)</code></u> and  <u> <code>UpdatePersonAsync(~)</code></u> execute  <code>GET GetPersons</code>,  <code>GET GetPersonById/{Id}</code> and  <code>PUT UpdatePerson</code> APIs. 
	</p>
	<p>
	These endpoints are not part of this application. You will need to create your own endpoints if you want to make API calls.
	<p>
</div>

## Code Landmarks
The project folders are described here.

<b><code>root project folder</code></b>
<div style="padding-left: 30px;">
	<p>
	The <code>Program.cs</code> and <code>ProcessWorker.cs</code> files are located in the root project folder.
	You will modify the ProcessWorker.cs file to define the console code you want to execute.
	</p>
</div>

<b><code>/Menu</code></b>
<div style="padding-left: 30px;">
	<p>
	This folder contains all of the menu code. These menu files are important examples.
	</p>
	<p>
	<code>MainMenuExp.cs</code>
	<br>
	<code>PersonUpdateMenu.cs</code>
	</p>
</div>

<b><code>/Model</code></b>
<div style="padding-left: 30px;">
	<p>
	The <code>PersonExt.cs</code> file contains interesting code related to formatting the output in portrait or landscape orientation. This is worth looking at when output formatting is important.
	</p>
</div>

<b><code>/Helper / Worker and /Test</code></b>
<div style="padding-left: 30px;">
	<p>
	These folders contain example code and can be removed.
	</p>
</div>

