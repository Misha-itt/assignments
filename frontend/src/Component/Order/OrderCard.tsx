import React from "react";
import { CartItem } from "./OrderSlice";


export type PaymentMethod = "COD" | "UPI" | "CARD";


export type Order = {
  id: number;
  userName: string;
  orderDate: string;
  totalAmount: number;
  items: CartItem[];
  paymentMethod: PaymentMethod; 
  status: "Pending" | "Paid" | "Failed";
};

interface Props {
  order: Order;
}

const OrderCard: React.FC<Props> = ({ order }) => {
  return (
    <div className="order-card">
      <p><strong>User:</strong> {order.userName}</p>
      <p><strong>Date:</strong> {new Date(order.orderDate).toLocaleDateString()}</p>
      <p><strong>Total:</strong> ₹{order.totalAmount}</p>

      <p><strong>Payment:</strong> {order.paymentMethod}</p>
      <p><strong>Status:</strong> 
        <span className={`status ${order.status.toLowerCase()}`}>
          {order.status}
        </span>
      </p>
    </div>
  );
};

export default OrderCard;