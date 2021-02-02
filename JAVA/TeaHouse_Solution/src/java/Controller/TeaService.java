package Controller;

import Model.QueriedTealeaves;
import Model.Tea;
import Model.Tealeaf;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
@XmlAccessorType(XmlAccessType.FIELD)
public class TeaService implements Serializable{

    private static TeaService instance;

    public TeaService() {
        Tealeaf javaplanet = new Tealeaf();
        javaplanet.setName("Javaplanet");
        javaplanet.setVariety("Oolong");
        javaplanet.setBrand("Fair trade");
        javaplanet.setAcidity("Low");
        javaplanet.setFlavour("Fruit");
        javaplanet.setRegion("Java Island");
        javaplanet.setUrl("www.javaplanet.hu");
        
        Tea icetea = new Tea();
        icetea.setName("Ice Tea");
        icetea.setQuantity(500);
        icetea.setBaseprice(490);
        icetea.setSales(5);
        icetea.setTotal(12);
        
        Tea bubbletea = new Tea();
        bubbletea.setName("Bubble Tea");
        bubbletea.setQuantity(200);
        bubbletea.setBaseprice(350);
        bubbletea.setSales(7);
        bubbletea.setTotal(11);
        
        javaplanet.getTeas().add(bubbletea);
        javaplanet.getTeas().add(icetea);
        tealeaves.add(javaplanet);
        
        Tealeaf machate = new Tealeaf();
        machate.setName("Machate");
        machate.setVariety("White");
        machate.setBrand("Organic");
        machate.setAcidity("Medium");
        machate.setFlavour("Spiced");
        machate.setRegion("Chinese");
        machate.setUrl("www.machate.hu");
        
        Tea spicedtea = new Tea();
        spicedtea.setName("Spicy Tea");
        spicedtea.setQuantity(200);
        spicedtea.setBaseprice(350);
        spicedtea.setSales(7);
        spicedtea.setTotal(11);
        
       machate.getTeas().add(spicedtea);
       tealeaves.add(machate); 
        
    }
    
    public static TeaService getInstance(){
        if (instance == null) {
            instance = new TeaService();
        }
        return instance;
    }
    
    @XmlElement
    private List<Tealeaf> tealeaves = new ArrayList<>();

    public List<Tealeaf> getTealeaves() {
        return tealeaves;
    }
    
    public QueriedTealeaves getQueriedTealeaves(String tealeaf){
        QueriedTealeaves local = new QueriedTealeaves();
        for (Tealeaf t : tealeaves) {
            if (t.getName().toLowerCase().trim().equals(tealeaf.toLowerCase().trim())) {
                local.setTealeaf(t);
            }
        }
                
        return local;
    }
    
}
