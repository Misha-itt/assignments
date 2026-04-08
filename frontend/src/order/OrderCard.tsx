import React from "react";

export type Order = {
  id: number;
  userName: string;
  orderDate: string;
  totalAmount: number;
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
    </div>
  );
};

export default OrderCard;