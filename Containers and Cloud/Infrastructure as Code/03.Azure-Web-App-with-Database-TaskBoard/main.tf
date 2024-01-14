terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.89.0"
    }
  }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "TaskBoardRG" {
  name     = var.resource_group_name
  location = var.resource_group_location
}

resource "azurerm_service_plan" "TaskBoardSP" {
  name                = var.service_plan_name
  resource_group_name = azurerm_resource_group.TaskBoardRG.name
  location            = azurerm_resource_group.TaskBoardRG.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "TaskBoardLWA" {
  name                = var.linux_web_app_name
  resource_group_name = azurerm_resource_group.TaskBoardRG.name
  location            = azurerm_resource_group.TaskBoardRG.location
  service_plan_id     = azurerm_service_plan.TaskBoardSP.id

  connection_string {
    name  = "DefaultConnection"
    type  = "SQLAzure"
    value = "Data Source=tcp:${azurerm_mssql_server.TaskBoardDBS.name},1433;Initial Catalog=${azurerm_mssql_database.TaskBoardDB.name};User ID=${azurerm_mssql_server.TaskBoardDBS.administrator_login};Password=${azurerm_mssql_server.TaskBoardDBS.administrator_login_password};Trusted_Connection=False; MultipleActiveResultSets=True;"
  }

  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
    always_on = false
  }
}

resource "azurerm_app_service_source_control" "TaskBoardSC" {
  repo_url               = var.source_control_repo_url
  branch                 = "main"
  use_manual_integration = true
  app_id                 = azurerm_linux_web_app.TaskBoardLWA.id
}

resource "azurerm_mssql_server" "TaskBoardDBS" {
  name                         = var.mssql_server_name
  resource_group_name          = azurerm_resource_group.TaskBoardRG.name
  location                     = azurerm_resource_group.TaskBoardRG.location
  administrator_login          = "dbusername"
  administrator_login_password = "SoftUn!2024"
  version                      = "12.0"
}

resource "azurerm_mssql_database" "TaskBoardDB" {
  name           = var.mssql_database_name
  server_id      = azurerm_mssql_server.TaskBoardDBS.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  max_size_gb    = 2
  sku_name       = "S0"
  zone_redundant = false
}

resource "azurerm_mssql_firewall_rule" "TaskBoardDBF" {
  name             = var.mssql_firewall_rule_name
  server_id        = azurerm_mssql_server.TaskBoardDBS.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}