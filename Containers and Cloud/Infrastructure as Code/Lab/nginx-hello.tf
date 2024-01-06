terraform {
  # provider requirements are declared in 'required_providers'
  required_providers {
    #provider`s local name
    docker = {
      # global source address for the provider
      source = "kreuzwerker/docker",
      # version 
      version = "~> 3.0.2"
    }
  }
}

# configure the specified provider, in this case - "docker"
provider "docker" {
  host = "npipe:////./pipe/docker_engine"
}

# resource blocks are used to defined components of our infrastructure
# the first string is the docker resource type, in this case - "docker_image"
# the second string is the docker resource name, in this case - "nginx"
# the two strings combined make a unique id
resource "docker_image" "nginx" {
  #name of the docker image we want to use (from docker hub)
  name = "nginxdemos/hello"
}

# define a resource block for the container that we want to create from the nginxdemos/hello image
resource "docker_container" "nginx" {
  # defined the image we want to use from the previously created resource
  image = resource.docker_image.nginx.name
  # the container`s name
  name = "nginx-container"

  # define the ports
  ports {
    internal = 80
    external = 5000
  }
}