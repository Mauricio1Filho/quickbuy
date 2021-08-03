docker build --network=host -t registry.dubaismoke.net.br:5000/quickbuy:1.0.0 -f ./QuickBuy.Web/Dockerfile .
docker rm -f quickbuy
docker run -d --name quickbuy -p 4050:80 --restart=always registry.dubaismoke.net.br:5000/quickbuy:1.0.0