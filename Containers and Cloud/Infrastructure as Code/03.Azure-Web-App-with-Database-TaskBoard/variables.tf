variable "resource_group_name" {
  type        = string
  description = "Resource group name in Azure"
}

variable "resource_group_location" {
  type        = string
  description = "Resource group location"
}

variable "service_plan_name" {
  type        = string
  description = "Service plan name in Azure"
}

variable "linux_web_app_name" {
  type        = string
  description = "Linux web app name in Azure"
}

variable "source_control_repo_url" {
  type        = string
  description = "Source control repo url"
}

variable "mssql_server_name" {
  type        = string
  description = "MSSQL server name"
}

variable "mssql_database_name" {
  type        = string
  description = "MSSQL database name"
}

variable "mssql_firewall_rule_name" {
  type        = string
  description = "MSSQL firewall rule name"
}