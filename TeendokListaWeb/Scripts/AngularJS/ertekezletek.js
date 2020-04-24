var app = angular.module("ertekezletek", []);

app.controller('tabledata', function ($scope, $http) {
    $scope.ertekezletekArr = []; // Üres tömb létrehozása
    $scope.selected = {};
    // Adatok lekérdezése
    $http.get("/api/Ertekezletek")
        .then(function (response) {
            // Tömbök feltöltése
            angular.forEach(response.data, function (data) {
                data.kezdet_datum = new Date(data.kezdet_datum);
                if (data.veg_datum) {
                    data.veg_datum = new Date(data.veg_datum);
                }
            });
            $scope.ertekezletekArr = response.data;
        })
        .catch(function (response) {
            console.log(response);
            $scope.error = response.statusText;
        });

    // Sorbarendezés
    $scope.sort = function (keyname) {
        if (keyname === $scope.sortKey) {
            $scope.reverse = !$scope.reverse;
        }
        $scope.sortKey = keyname;
    }

    // Kijelölés
    $scope.select = function (ertekezlet) {
        $scope.selected = ertekezlet;
    }

    // Mentés
    $scope.save = function (ertekezlet) {
        console.log(ertekezlet);
        if (ertekezlet.id) {
            $scope.put(ertekezlet)
        }
        else {
            $scope.post(ertekezlet);
        }
    }

    // Létrehozás
    $scope.post = function (ertekezlet) {
        $http.post("api/Ertekezletek", JSON.stringify(ertekezlet))
            .then(function (response) {
                ertekezlet.id = response.data.id;
                $scope.ertekezletekArr.push(ertekezlet);

                $scope.selected = null;
            })
            .catch(function (response) {
                console.log(response);
                $scope.error = response.data.Message;
            });
    }

    // Módosítás
    $scope.put = function (ertekezlet) {
        $http.put("api/Ertekezletek", JSON.stringify(ertekezlet))
            .then(function () {
                // Kikeresés a tömbből
                //var index = $scope.dataArray.indexOf(ertekezlet);
                //$scope.dataArray[index] = ertekezlet;

                $scope.selected = null;
            })
            .catch(function (response) {
                console.log(response);
                $scope.error = response.data.Message;
            });
    }

    // Törlés
    $scope.delete = function (ertekezlet) {
        $http.delete("/api/Ertekezletek" + "/" + ertekezlet.id)
            .then(function () {
                var index = $scope.ertekezletekArr.indexOf(ertekezlet);
                $scope.ertekezletekArr.splice(index, 1); 
        });
    }
});