terraform {
  # Define the required providers, specifying AzureRM.
  required_providers {
    azurerm = {
      # Global source address for the AzureRM provider.
      source  = "hashicorp/azurerm"
      # Specified version of the AzureRM provider.
      version = "3.89.0"
    }
  }
}

# Configure the AzureRM provider with required features block.
provider "azurerm" {
  features {}
}

# Generate a random integer to create a unique identifier.
resource "random_integer" "ri" {
  min = 10000
  max = 99999
}

# Create a new Resource Group in Azure.
resource "azurerm_resource_group" "deyordanov_RG" {
  # Name of the Resource Group, incorporating a unique identifier.
  name     = "ContactBooksRG${random_integer.ri.result}"
  # Geographic location of the Resource Group.
  location = "West Europe"
}

# Create a new Azure Service Plan.
# The azure service plan is a container for our web apps, API apps, mobile apps. If defines a set of
# compute resources for hosting the application. The SP is used to define the infrastructure of the
# application we are going to upload - it focuses on providing a managed hosting environment within the
# azure cloud platform.
resource "azurerm_service_plan" "deyordanov_service_plan" {
  # Name of the Azure Service Plan, including a unique identifier.
  name                = "ContactBookSP${random_integer.ri.result}"
  # Resource Group name for the Service Plan.
  resource_group_name = azurerm_resource_group.deyordanov_RG.name
  # Location, inheriting from the Resource Group.
  location            = azurerm_resource_group.deyordanov_RG.location
  # Operating system specified for the Service Plan.
  os_type             = "Linux"
  # Stock Keeping Unit, with "F1" indicating the free tier.
  sku_name            = "F1"
}

# Create a new Linux Web App in Azure.
# The linux web app is used for provisioning and managing Linux-based web applications on the 
# microsoft azure cloud platform.
resource "azurerm_linux_web_app" "deyordanov_linux_web_app" {
  # Name of the Linux Web App, including a unique identifier.
  name                = "ContactBookLWA${random_integer.ri.result}"
  # Resource Group name for the Web App.
  resource_group_name = azurerm_resource_group.deyordanov_RG.name
  # Location, inheriting from the Resource Group.
  location            = azurerm_resource_group.deyordanov_RG.location
  # Service Plan ID for the Web App.
  service_plan_id     = azurerm_service_plan.deyordanov_service_plan.id

  site_config {
    application_stack {
      # Node.js version for the application stack.
      node_version = "16-lts"
    }
    # Configuration to keep the app always on; false indicates off.
    always_on = false
  }
}

# Configure source control for the Azure App Service.
# It is used to manage the source control configuration for an Azure App Service.
resource "azurerm_app_service_source_control" "deyordanov_source_control" {
  # App ID for the Linux Web App.
  app_id              = azurerm_linux_web_app.deyordanov_linux_web_app.id
  # Repository URL for the source code.
  repo_url            = "https://github.com/nakov/ContactBook"
  # Branch in the repository to deploy from.
  branch              = "master"
  # Manual integration setting; true requires manual deployment.
  use_manual_integration = true
}
