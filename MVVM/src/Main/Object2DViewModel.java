package Main;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;



public class Object2DViewModel 
{
    private Object2D person_;
    
    private StringProperty nameProperty_;
    private StringProperty widthProperty_;
    private StringProperty heightProperty_;
    
    
    public Object2DViewModel(Object2D person) 
    {
    	// Create person object:
        this.person_ = person;

        //Init StringProperty:
        this.nameProperty_ = new SimpleStringProperty(person.get_name().toString());
        
        this.widthProperty_ = new SimpleStringProperty(Integer.toString(person.get_size().get_width()));
        this.heightProperty_ = new SimpleStringProperty(Integer.toString(person.get_size().get_height()));
    }

    
    
    /* 
     * Getters and Setters: 
    */
    
    public StringProperty nameProperty() {
        return nameProperty_;
    }

    public StringProperty widthProperty() {
        return widthProperty_;
    }

    public StringProperty heightProperty() {
        return heightProperty_;
    }

    /* 
     * Data Modifiers:
    */
    
    public void updateName(String name) 
    {
        person_.set_name(name);
        nameProperty_.set(name);
    }

    public void updateWidth(int width) 
    {
        Size _currentSize = person_.get_size();
        Size _newSize = new Size(width, _currentSize.get_height());
        person_.set_size(_newSize);
        
        widthProperty_.set(Integer.toString(width));
    }
    
    public void updateHeight(int height) 
    {
        Size _currentSize = person_.get_size();
        Size _newSize = new Size(_currentSize.get_width(), height);
        person_.set_size(_newSize);
        
        heightProperty_.set(Integer.toString(height));
    }
}