output "webapp_url" {
  value = azurerm_linux_web_app.TaskBoardLWA.default_hostname
}

output "webapp_ips" {
  value = azurerm_linux_web_app.TaskBoardLWA.outbound_ip_addresses
}