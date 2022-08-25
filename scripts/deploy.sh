#echo "Extracting file"
#tar -xvf $1
#rm -rf /var/www/donationprojectapi
#cp -rf $1 /var/www/donationprojectapi
sudo systemctl restart kestrel-donationprojectapi
