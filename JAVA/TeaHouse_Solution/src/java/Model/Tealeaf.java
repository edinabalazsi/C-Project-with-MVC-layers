package Model;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name ="tealeaf")
@XmlAccessorType(XmlAccessType.FIELD)
public class Tealeaf implements Serializable{
    //TL_ID TLNAME VARIETY BRAND ACIDITY FLAVOUR REGION	
    private static int nextID;
    @XmlElement
    private int id;
    @XmlElement
    private String name;
    @XmlElement
    private String variety;
    @XmlElement
    private String brand;
    @XmlElement
    private String acidity;
    @XmlElement
    private String flavour;
    @XmlElement
    private String region;
    @XmlElement
    private String url;
    @XmlElement
    private List<Tea> teas = new ArrayList<>();
    
    public Tealeaf() {
        this.id = nextID++;
    }
    
    public List<Tea> getTeas() {
        return teas;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getVariety() {
        return variety;
    }

    public void setVariety(String variety) {
        this.variety = variety;
    }

    public String getBrand() {
        return brand;
    }

    public void setBrand(String brand) {
        this.brand = brand;
    }

    public String getAcidity() {
        return acidity;
    }

    public void setAcidity(String acidity) {
        this.acidity = acidity;
    }

    public String getFlavour() {
        return flavour;
    }

    public void setFlavour(String flavour) {
        this.flavour = flavour;
    }

    public String getRegion() {
        return region;
    }

    public void setRegion(String region) {
        this.region = region;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 89 * hash + this.id;
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
        final Tealeaf other = (Tealeaf) obj;
        if (this.id != other.id) {
            return false;
        }
        return true;
    }
    
    
}
