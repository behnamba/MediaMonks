"use strict";

function Payment(Description, CreatedDate, Status, ProductId, Price, ProductTagId) {
    this.Description = Description;
    this.CreatedDate = CreatedDate;
    this.Status = Status;
    this.ProductId = ProductId;
    this.Price = Price;
    this.ProductTagId = ProductTagId;
}

var Status = {
    Confiremd: 0,
    Rejected: 1
};