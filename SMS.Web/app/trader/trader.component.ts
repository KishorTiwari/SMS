import { Component } from '@angular/core';
@Component({
    selector: 'trader',
    moduleId: module.id,
    templateUrl: 'trader.component.html',
    styleUrls: ['trader.component.css']
})
export class TraderComponent {
    Title: string = "Trader List";
    Traders: string[] = ["Car Sel", "G Autos", "Smart Car Rental", "2 Cheap Cars", "U-Sell"];
    Dynamic: string = "Change Me";
    reset(): void {
        this.Dynamic = "";
    }
}