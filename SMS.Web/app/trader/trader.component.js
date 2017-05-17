"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var TraderComponent = (function () {
    function TraderComponent() {
        this.Title = "Trader List";
        this.Traders = ["Car Sel", "G Autos", "Smart Car Rental", "2 Cheap Cars", "U-Sell"];
        this.Dynamic = "Change Me";
    }
    TraderComponent.prototype.reset = function () {
        this.Dynamic = "";
    };
    return TraderComponent;
}());
TraderComponent = __decorate([
    core_1.Component({
        selector: 'trader',
        moduleId: module.id,
        templateUrl: 'trader.component.html',
        styleUrls: ['trader.component.css']
    })
], TraderComponent);
exports.TraderComponent = TraderComponent;
//# sourceMappingURL=trader.component.js.map