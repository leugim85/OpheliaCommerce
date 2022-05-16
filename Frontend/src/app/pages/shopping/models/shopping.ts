export interface Shopping {
    clientId: number;
    date: Date;
    products: [
        {
            id: number;
            quantity: number;
        }
    ]
}