using AbstractFactoryDesignPattern.Factories;
using AbstractFactoryDesignPattern.Products.Contracts;

DellManufacturer dellManufacturer = new DellManufacturer();
AsusManufacturer asusManufacturer = new AsusManufacturer();

IGpu dellGpu = dellManufacturer.CreateGpu();
IMonitor dellMonitor = dellManufacturer.CreateMonitor();

IGpu asusGpu = asusManufacturer.CreateGpu();
IMonitor asusMonitor = asusManufacturer.CreateMonitor();

dellGpu.Assemble();
dellMonitor.Assemble();

asusGpu.Assemble();
asusMonitor.Assemble();