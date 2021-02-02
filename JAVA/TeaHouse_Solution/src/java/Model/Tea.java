package Model;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name ="tea")
@XmlAccessorType(XmlAccessType.FIELD)
public class Tea implements Serializable{
    //TEA_ID TEANAME QUANTITY BASEPRICE SALES TOTAL
    private static int nextID;
    @XmlElement
    private int id;
    @XmlElement
    private String name;
    @XmlElement
    private int quantity;
    @XmlElement
    private int baseprice;
    @XmlElement
    private int sales;
    @XmlElement
    private int total;

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public int getBaseprice() {
        return baseprice;
    }

    public void setBaseprice(int baseprice) {
        this.baseprice = baseprice;
    }

    public int getSales() {
        return sales;
    }

    public void setSales(int sales) {
        this.sales = sales;
    }

    public int getTotal() {
        return total;
    }

    public void setTotal(int total) {
        this.total = total;
    }

    public Tea() {
        this.id = nextID++;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 59 * hash + this.id;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Tea other = (Tea) obj;
        if (this.id != other.id) {
            return false;
        }
        return true;
    }
    
    
}
