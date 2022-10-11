
# DiffidentDeckard_SotMBaseMod

This serves as a base to make a mod for Sentinels of the Multiverse.

It builds off of the Sample Mod that Handelabra provides in their Workshop Sample:
https://github.com/Handelabra/WorkshopSample

You want both your main mod dll and your unit testing dll to reference this NuGet package.
It includes some string constants and extension methods useful while developing a mod.
It also contains Test Heroes, Villain, and Environment that all do nothing, for the purposes of testing.
These TestTurnTakers won't appear in your mod when you finalize and export it, unless you actually add their decklists and files to your mod.
It adds setup methods that will automatically use the TestTurnTakers, making writing Unit Tests easy and more consistent.
None of this is intended to be a sample to show you how to write a mod, it just makes things simpler and quicker, especially writing unit tests.

In order to correctly use these TestTurnTakers, you will need to add the SotM_ModBase assembly in your unit test's Setup.cs file, like below:
  
  // Add the SotM_ModBase assembly to your unit test's Setup.cs
  var modBaseAssembly = Assembly.GetAssembly(typeof(TestHero1CharacterCardController));
  ModHelper.AddAssembly(nameof(SotM_ModBase), modBaseAssembly);

  // Add *your* mod's assembly as well
  var yourModAssembly = Assembly.GetAssembly(typeof(SomeNameSpaceInYourModGoesHere)); // replace with your own type
  ModHelper.AddAssembly(nameof(yourMod), yourModAssembly); // replace with your own namespace
