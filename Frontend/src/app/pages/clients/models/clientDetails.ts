export interface ClientDetail {
    id:         number;
    name:       string;
    totalSpend: number;
    email:      string;
    shoppings:  Shopping[];
}

export interface Shopping {
    id:       number;
    date:     Date;
    payValue: number;
    products: Product[];
}

export interface Product {
    id:          number;
    name:        string;
    price:       number;
    description: string;
    quantity:    number;
}
