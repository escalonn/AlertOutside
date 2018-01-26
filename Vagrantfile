# -*- mode: ruby -*-
# vi: set ft=ruby :

# DEFINITION - VAGRANT
Vagrant.require_version ">= 2.0.1", "< 2.1.0"

Vagrant.configure("2") do |config|
  # DEFINITION - BOX
  config.vm.box = "ubuntu/xenial64"
  config.vm.box_version = "20180122.0.0"

  # DEFINITION - NETWORK
  config.vm.network "forwarded_port", guest: 10000, host: 10000, host_ip: "127.0.0.1"
  config.vm.network "forwarded_port", guest: 20000, host: 20000, host_ip: "127.0.0.1"
  config.vm.network "forwarded_port", guest: 30000, host: 30000, host_ip: "127.0.0.1"
  config.vm.network "forwarded_port", guest: 40000, host: 40000, host_ip: "127.0.0.1"

  # DEFINITION - SYNCED FOLDER
  config.vm.synced_folder ".", "/vagrant"

  # DEFINITION - VIRTUALBOX
  config.vm.provider "virtualbox" do |vb|
    vb.memory = "2048"
    vb.customize [ "modifyvm", :id, "--uartmode1", "disconnected" ]
  end

  # DEFINITION - PROVISION
  config.vm.provision "shell", path: "Vagrantup.sh"
end
