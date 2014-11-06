'use strict';
app.controller('booksController', ['$scope', '$location', 'booksService', function ($scope, $location, booksService) {
	$scope.books = [];

	$scope.book = {
		title: "",
		author: "",
		isbn: ""
	};

	$scope.message = "";

	booksService.getBooks().then(function (results) {
		$scope.books = results.data;
	}, function (error) {
		alert(error.data.message);
	});

	$scope.create = function () {

		booksService.create($scope.book).then(function (result) {

			$scope.message = 'Book Created Successfully';

			$scope.books.push(result.data);

			//$location.path('/books');

		},
		 function (err) {
		 	$scope.message = err.error_description;
		 });
	};

}]);