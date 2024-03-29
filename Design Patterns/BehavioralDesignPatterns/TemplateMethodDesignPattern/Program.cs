using TemplateMethodDesignPattern.GameLoaders;

BaseGameLoader deadByDaylightLoader = new DeadByDaylightLoader();
deadByDaylightLoader.Load();

BaseGameLoader ghostOfTsushimaLoader =  new GhostOfTsushimaLoader();
ghostOfTsushimaLoader.Load();