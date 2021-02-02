package Model;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement(name ="queriedTeas")
@XmlAccessorType(XmlAccessType.FIELD)
public class QueriedTealeaves implements Serializable{
    
    @XmlElement(name ="tealeaf")
    private Tealeaf tealeaf;
    
    public Tealeaf getTealeaf() {
        return tealeaf;
    }

    public void setTealeaf(Tealeaf tealeaf) {
        this.tealeaf = tealeaf;
    }

    public QueriedTealeaves() {
    }

}
