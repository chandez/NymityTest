import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { ProductService } from './product.service';
import { Product } from './product';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit, OnDestroy {

    cols: any[];
    products: Product[];
    selectedItens: Product[] = [];
    selectedProduct: Product;
    subscription: Subscription;

    constructor(private productService: ProductService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.subscription = this.productService.list()
            .subscribe(
                (products) => this.products = products,
                (error) => console.log(error)
            );

        this.cols = [
            { field: 'productID', header: 'ProductID' },
            { field: 'productName', header: 'ProductName' },
            { field: 'quantityPerUnit', header: 'QuantityPerUnit' },
            { field: 'unitPrice', header: 'UnitPrice' },
            { field: 'unitsInStock', header: 'UnitsInStock' },
            { field: 'unitsOnOrder', header: 'UnitsOnOrder' }
        ];
    }

    onSelect(selectedProduct: Product) {
        this.selectedItens.push(selectedProduct);
        console.log(this.selectedItens);
    }

    onEdit(selectedProduct: Product) {
        this.router.navigate(['edit'], { relativeTo: this.route });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

}
