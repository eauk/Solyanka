

(function() {
    var app = angular.module('store', []);

    app.controller('StoreController', function() {
        this.products = gems;
    });

    var gems = [
        {
            name: 'Dodecahedron',
            price: 2.95,
            description: 'some descriptions',
            canPurchase: true,
            soldOut: false,
        },
        {
            name: 'Dodecahedron2',
            price: 3.87,
            description: 'some descriptions2',
            canPurchase: true,
            soldOut: true,
        },
        {
            name: 'Dodecahedron3',
            price: 1.17,
            description: 'some descriptions3',
            canPurchase: true,
            soldOut: false,
        }];
})();



